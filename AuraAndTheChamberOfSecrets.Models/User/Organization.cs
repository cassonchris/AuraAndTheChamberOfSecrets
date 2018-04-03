using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuraAndTheChamberOfSecrets.Models.User
{
    public class Organization : BaseModel
    {
        [Required]
        public string Name { get; set; }

        public IList<ApplicationUserOrganization> UserLinks { get; set; }
    }
}
