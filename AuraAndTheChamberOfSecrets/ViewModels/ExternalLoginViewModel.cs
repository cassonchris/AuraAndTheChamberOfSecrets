using System.ComponentModel.DataAnnotations;

namespace AuraAndTheChamberOfSecrets.ViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
