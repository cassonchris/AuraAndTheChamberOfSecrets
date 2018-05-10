using System;
using AuraAndTheChamberOfSecrets.Services.Interface;
using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Nest.JsonNetSerializer;
using Newtonsoft.Json;

namespace AuraAndTheChamberOfSecrets.Services.Config
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAuraAndTheChamberOfSecretsServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IAccountService, AccountService>();

            var pool = new SingleNodeConnectionPool(new Uri(config.GetSection("ElasticSearch")["Uri"]));
            var elasticSettings = new ConnectionSettings(pool, 
                (builtin, settings) => new JsonNetSerializer(builtin, settings, () => new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.All
                }));
            elasticSettings.DefaultIndex("question");
            elasticSettings.DefaultTypeName("default");
            services.AddSingleton<IElasticClient>(new ElasticClient(elasticSettings));
        }
    }
}
