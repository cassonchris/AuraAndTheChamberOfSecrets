using System;
using System.ComponentModel.DataAnnotations;

namespace AuraAndTheChamberOfSecrets.Models
{
    public class Answer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string AnswerText { get; set; }

        [Required]
        public Question Question { get; set; }
    }
}
