using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuraAndTheChamberOfSecrets.Models.User
{
    public class UserProfile : BaseModel
    {
        [Required]
        public Guid ApplicationUserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public IList<UserOrganization> OrganizationLinks { get; set; }
    }
}
