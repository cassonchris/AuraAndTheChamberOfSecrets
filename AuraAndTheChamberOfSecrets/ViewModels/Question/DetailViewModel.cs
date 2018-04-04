using System.ComponentModel.DataAnnotations;

namespace AuraAndTheChamberOfSecrets.ViewModels.Question
{
    public class DetailViewModel
    {
        public Models.Question Question { get; set; }

        [Required(ErrorMessage = "You can't submit a blank answer")]
        [Display(Name = "Your Answer")]
        public string NewAnswer { get; set; }
    }
}
