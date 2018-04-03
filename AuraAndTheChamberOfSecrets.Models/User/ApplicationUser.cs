using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AuraAndTheChamberOfSecrets.Models.User
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public IList<ApplicationUserOrganization> OrganizationLinks { get; set; }
    }
}
