using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuraAndTheChamberOfSecrets.Models.User
{
    public class Organization
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IList<ApplicationUserOrganization> UserLinks { get; set; }
    }
}
