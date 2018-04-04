using System.ComponentModel.DataAnnotations;

namespace AuraAndTheChamberOfSecrets.ViewModels.Question
{
    public class AskViewModel
    {
        [Required(ErrorMessage = "Write a brief summary of your question.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A question is required.")]
        [Display(Name = "Question")]
        public string QuestionText { get; set; }
    }
}
