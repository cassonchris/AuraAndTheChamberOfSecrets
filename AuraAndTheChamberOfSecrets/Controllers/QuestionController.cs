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
            var vm = new AskViewModel
            {
                Question = new Question
                {
                    Username = User.Identity.Name
                }
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Ask(AskViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            vm.Question.Username = User.Identity.Name;
            await _questionService.CreateQuestionAsync(vm.Question);

            return RedirectToAction(nameof(Search));
        }
    }
}