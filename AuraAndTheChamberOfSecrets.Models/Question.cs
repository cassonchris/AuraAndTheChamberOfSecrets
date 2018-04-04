using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AuraAndTheChamberOfSecrets.Models.User;

namespace AuraAndTheChamberOfSecrets.Models
{
    public class Question : BaseModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string QuestionText { get; set; }

        [Required]
        public UserProfile User { get; set; }

        public Organization Organization { get; set; }

        public IList<Answer> Answers { get; set; }
    }
}
