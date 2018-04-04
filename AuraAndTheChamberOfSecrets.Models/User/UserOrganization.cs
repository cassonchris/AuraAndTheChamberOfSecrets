using System;

namespace AuraAndTheChamberOfSecrets.Models.User
{
    public class UserOrganization
    {
        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
