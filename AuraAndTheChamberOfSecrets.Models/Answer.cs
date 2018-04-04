using System.ComponentModel.DataAnnotations;
using AuraAndTheChamberOfSecrets.Models.User;

namespace AuraAndTheChamberOfSecrets.Models
{
    public class Answer : BaseModel
    {
        [Required]
        public string AnswerText { get; set; }

        [Required]
        public Question Question { get; set; }

        [Required]
        public UserProfile User { get; set; }
    }
}
