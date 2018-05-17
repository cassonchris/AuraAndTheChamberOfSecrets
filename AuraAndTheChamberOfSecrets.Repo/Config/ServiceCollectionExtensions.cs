using AuraAndTheChamberOfSecrets.Repo.EntityFramework;
using AuraAndTheChamberOfSecrets.Repo.EntityFramework.Context;
using AuraAndTheChamberOfSecrets.Repo.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuraAndTheChamberOfSecrets.Repo.Config
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the DbContext and repositories.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void AddAuraAndTheChamberOfSecretsEntityFrameworkRepositories(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AuraAndTheChamberOfSecretsDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("AuraAndTheChamberOfSecretsConnection")));

            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
        }
    }
}
