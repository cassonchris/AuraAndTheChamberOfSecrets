using System;
using System.Linq;
using System.Threading.Tasks;
using AuraAndTheChamberOfSecrets.Models;
using AuraAndTheChamberOfSecrets.Repo.Interface;
using AuraAndTheChamberOfSecrets.Services.Interface;
using Markdig;

namespace AuraAndTheChamberOfSecrets.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepo;

        public QuestionService(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        /// <summary>
        /// todo - add elastic search
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public IQueryable<Question> SearchQuestions(string searchString)
        {
            return _questionRepo.Query(q => q.QuestionText.Contains(searchString));
        }

        public async Task CreateQuestionAsync(Question question)
        {
            // parse the question text to html
            question.QuestionText = Markdown.ToHtml(question.QuestionText);

            await _questionRepo.AddAsync(question);
            await _questionRepo.SaveAsync();
        }

        public Question GetQuestion(Guid id)
        {
            return _questionRepo.GetSingleById(id);
        }

        public async Task AddAnswerAsync(Answer answer, Guid questionId)
        {
            // parse the answer text to html
            answer.AnswerText = Markdown.ToHtml(answer.AnswerText);

            // link the question and answer
            var question = GetQuestion(questionId);
            answer.Question = question;
            question.Answers.Add(answer);

            await _questionRepo.SaveAsync();
        }
    }
}
