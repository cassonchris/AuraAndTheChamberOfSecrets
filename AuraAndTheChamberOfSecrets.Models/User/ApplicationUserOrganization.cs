using System;

namespace AuraAndTheChamberOfSecrets.Models.User
{
    public class ApplicationUserOrganization
    {
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
