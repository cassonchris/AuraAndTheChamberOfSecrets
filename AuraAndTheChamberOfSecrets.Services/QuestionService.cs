using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuraAndTheChamberOfSecrets.Models;
using AuraAndTheChamberOfSecrets.Repo.Interface;
using AuraAndTheChamberOfSecrets.Services.Interface;
using Markdig;
using Nest;

namespace AuraAndTheChamberOfSecrets.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly IElasticClient _elasticClient;

        public QuestionService(IQuestionRepository questionRepo, IElasticClient elasticClient)
        {
            _questionRepo = questionRepo;
            _elasticClient = elasticClient;
        }

        /// <summary>
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Question>> SearchQuestionsAsync(string searchString)
        {
            // search elasticsearch
            var results = await _elasticClient.SearchAsync<Question>(s => s.MatchAll(m => m.Name(searchString)));
            if (results.IsValid)
            {
                // return the results from elasticsearch
                return results.Hits.Select(h => h.Source);
            }
            else
            {
                // fall back to search database directly
                return _questionRepo.Query(q => q.QuestionText.Contains(searchString));
            }
        }

        public async Task CreateQuestionAsync(Question question)
        {
            // parse the question text to html
            question.QuestionText = Markdown.ToHtml(question.QuestionText);

            await _questionRepo.AddAsync(question);
            await _questionRepo.SaveAsync();

            // index to elastic search
            await _elasticClient.IndexAsync(question, i => 
                i.Index<Question>()
                    .Type("default")
                    .Id(question.Id));
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

            // update the elastic search index
            await _elasticClient.IndexAsync(question, i =>
                i.Index<Question>()
                    .Type("default")
                    .Id(question.Id));
        }
    }
}
