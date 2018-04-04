using System;
using System.Threading.Tasks;
using AuraAndTheChamberOfSecrets.Models;
using AuraAndTheChamberOfSecrets.Services.Interface;
using AuraAndTheChamberOfSecrets.ViewModels.Question;
using Microsoft.AspNetCore.Mvc;

namespace AuraAndTheChamberOfSecrets.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IAccountService _accountService;

        public QuestionController(IQuestionService questionService, IAccountService accountService)
        {
            _questionService = questionService;
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View(new SearchViewModel());
        }

        [HttpPost]
        public IActionResult Search(SearchViewModel search)
        {
            if (!ModelState.IsValid)
            {
                return View(search);
            }

            search.SearchResults = _questionService.SearchQuestions(search.SearchString);

            return View(search);
        }

        [HttpGet]
        public IActionResult Ask()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ask(AskViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var user = _accountService.GetUserProfileByUsername(User.Identity.Name);

            var question = new Question
            {
                Title = vm.Title,
                QuestionText = vm.QuestionText,
                User = user
            };
            await _questionService.CreateQuestionAsync(question);

            return RedirectToAction(nameof(Search));
        }

        [HttpGet]
        [Route("[controller]/{id:Guid}/[action]")]
        public IActionResult Detail(Guid id)
        {
            var question = _questionService.GetQuestion(id);

            var vm = new DetailViewModel {Question = question};

            return View(vm);
        }
    }
}