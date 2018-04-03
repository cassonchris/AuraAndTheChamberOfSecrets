using System.Linq;
using System.Threading.Tasks;
using AuraAndTheChamberOfSecrets.Models;

namespace AuraAndTheChamberOfSecrets.Services.Interface
{
    public interface IQuestionService
    {
        IQueryable<Question> SearchQuestions(string searchString);
        Task CreateQuestionAsync(Question question);
    }
}
