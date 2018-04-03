using System.ComponentModel.DataAnnotations;

namespace AuraAndTheChamberOfSecrets.ViewModels.Question
{
    public class AskViewModel
    {
        [Required]
        public Models.Question Question { get; set; }
    }
}
