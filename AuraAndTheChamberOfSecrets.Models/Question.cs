using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AuraAndTheChamberOfSecrets.Models.User;

namespace AuraAndTheChamberOfSecrets.Models
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string QuestionText { get; set; }

        public Organization Organization { get; set; }

        public IList<Answer> Answers { get; set; }
    }
}
