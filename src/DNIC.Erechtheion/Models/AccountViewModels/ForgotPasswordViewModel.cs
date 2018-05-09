using System.ComponentModel.DataAnnotations;

namespace DNIC.Erechtheion.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
