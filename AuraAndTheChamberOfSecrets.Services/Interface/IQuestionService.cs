using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuraAndTheChamberOfSecrets.Models;

namespace AuraAndTheChamberOfSecrets.Services.Interface
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> SearchQuestionsAsync(string searchString);
        Task CreateQuestionAsync(Question question);
        Question GetQuestion(Guid id);
        Task AddAnswerAsync(Answer answer, Guid questionId);
    }
}
