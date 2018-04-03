using System.ComponentModel.DataAnnotations;

namespace AuraAndTheChamberOfSecrets.Models
{
    public class Answer : BaseModel
    {
        [Required]
        public string AnswerText { get; set; }

        [Required]
        public Question Question { get; set; }
    }
}
