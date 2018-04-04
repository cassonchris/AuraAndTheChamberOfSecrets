using System;
using System.Linq;
using System.Threading.Tasks;
using AuraAndTheChamberOfSecrets.Models;
using AuraAndTheChamberOfSecrets.Repo.Interface;
using AuraAndTheChamberOfSecrets.Services.Interface;

namespace AuraAndTheChamberOfSecrets.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepo;

        public QuestionService(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        public IQueryable<Question> SearchQuestions(string searchString)
        {
            return _questionRepo.Query(q => q.QuestionText.Contains(searchString));
        }

        public async Task CreateQuestionAsync(Question question)
        {
            await _questionRepo.AddAsync(question);
            await _questionRepo.SaveAsync();
        }

        public Question GetQuestion(Guid id)
        {
            return _questionRepo.GetSingleById(id);
        }
    }
}
