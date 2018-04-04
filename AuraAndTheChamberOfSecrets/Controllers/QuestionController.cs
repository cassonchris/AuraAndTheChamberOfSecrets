﻿using System.Threading.Tasks;
using AuraAndTheChamberOfSecrets.Models;
using AuraAndTheChamberOfSecrets.Services.Interface;
using AuraAndTheChamberOfSecrets.ViewModels.Question;
using Microsoft.AspNetCore.Mvc;

namespace AuraAndTheChamberOfSecrets.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
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

            var question = new Question
            {
                Title = vm.Title,
                QuestionText = vm.QuestionText,
                Username = User.Identity.Name
            };
            await _questionService.CreateQuestionAsync(question);

            return RedirectToAction(nameof(Search));
        }
    }
}