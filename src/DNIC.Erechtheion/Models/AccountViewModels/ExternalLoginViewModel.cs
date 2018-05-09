using System.ComponentModel.DataAnnotations;

namespace DNIC.Erechtheion.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
