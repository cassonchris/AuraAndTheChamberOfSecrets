using System.Collections.Generic;
using AuraAndTheChamberOfSecrets.Models.User;

namespace AuraAndTheChamberOfSecrets.ViewModels.Account
{
    public class ProfileViewModel
    {
        public UserProfile UserProfile { get; set; }
        public IEnumerable<Models.Question> UserQuestions { get; set; }
    }
}
