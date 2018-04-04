using AuraAndTheChamberOfSecrets.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuraAndTheChamberOfSecrets.Controllers.Api
{
    public class QuestionController : BaseApiController
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Search(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return BadRequest("Search string is empty");
            }

            var questions = _questionService.SearchQuestions(searchString);
            return Ok(questions);
        }
    }
}
