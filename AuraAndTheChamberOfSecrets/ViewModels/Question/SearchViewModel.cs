using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuraAndTheChamberOfSecrets.ViewModels.Question
{
    public class SearchViewModel
    {
        [Required(ErrorMessage = "It helps if you type something...")]
        public string SearchString { get; set; }

        public IEnumerable<Models.Question> SearchResults { get; set; }
    }
}
