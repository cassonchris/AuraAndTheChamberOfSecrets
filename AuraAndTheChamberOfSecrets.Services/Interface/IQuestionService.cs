using System.Linq;
using AuraAndTheChamberOfSecrets.Models;

namespace AuraAndTheChamberOfSecrets.Services.Interface
{
    public interface IQuestionService
    {
        IQueryable<Question> SearchQuestions(string searchString);
    }
}
