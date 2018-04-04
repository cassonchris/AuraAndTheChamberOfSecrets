using AuraAndTheChamberOfSecrets.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace AuraAndTheChamberOfSecrets.Services.Config
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAuraAndTheChamberOfSecretsServices(this IServiceCollection services)
        {
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
