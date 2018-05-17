using System;
using System.Threading.Tasks;
using AuraAndTheChamberOfSecrets.Models;
using AuraAndTheChamberOfSecrets.Repo.Config;
using AuraAndTheChamberOfSecrets.Repo.EntityFramework.Context;
using AuraAndTheChamberOfSecrets.Repo.Interface;
using AuraAndTheChamberOfSecrets.Services.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace AuraAndTheChamberOfSecrets.AdminCli
{
    class Program
    {
        static void Main(string[] args)
        {
            // build the configuration
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true);
            var configuration = configBuilder.Build();

            // build the service provider
            // todo - use the service collection extensions from the services project
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<Program, Program>();
            serviceCollection.AddDbContext<AuraAndTheChamberOfSecretsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AuraAndTheChamberOfSecretsConnection")));
            serviceCollection.AddAuraAndTheChamberOfSecretsEntityFrameworkRepositories();
            serviceCollection.AddAuraAndTheChamberOfSecretsServices(configuration);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // get the program and run the cli
            var program = serviceProvider.GetService<Program>();
            program.RunCli().Wait();
        }

        private readonly IQuestionRepository _questionRepo;
        private readonly IElasticClient _elasticClient;
        private const string Prompt = "AdminCli>";

        public Program(IQuestionRepository questionRepo, IElasticClient elasticClient)
        {
            _questionRepo = questionRepo;
            _elasticClient = elasticClient;
        }

        public async Task RunCli()
        {
            Console.Write(Prompt);

            string command;
            while ((command = Console.ReadLine()) != "exit")
            {
                switch (command)
                {
                    case "Test":
                        var questions = _questionRepo.Query(q => true);
                        foreach (var question in questions)
                        {
                            Console.WriteLine(question.Title);
                        }
                        break;
                    case "ReIndexQuestions":
                        await ReIndexQuestions();
                        break;
                    default:
                        Console.WriteLine("Do what now?");
                        break;
                }

                Console.Write(Prompt);
            }
        }

        /// <summary>
        /// todo - use a command interface or something instead of random methods in this class
        /// </summary>
        /// <returns></returns>
        public async Task ReIndexQuestions()
        {
            // delete the index
            await _elasticClient.DeleteIndexAsync("question");

            // get all questions
            var questions = _questionRepo.Query(q => true).Include(q => q.Answers);

            // todo - use bulk index
            foreach (var question in questions)
            {
                // index question
                await _elasticClient.IndexAsync(question, i =>
                    i.Index<Question>()
                        .Type("default")
                        .Id(question.Id));
            }
        }
    }
}
