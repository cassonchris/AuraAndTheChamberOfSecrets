using AuraAndTheChamberOfSecrets.Repo.EntityFramework;
using AuraAndTheChamberOfSecrets.Repo.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace AuraAndTheChamberOfSecrets.Repo.Config
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAuraAndTheChamberOfSecretsEntityFrameworkRepositories(this IServiceCollection services)
        {
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
        }
    }
}
