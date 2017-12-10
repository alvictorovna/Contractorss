using System.ComponentModel.DataAnnotations;

namespace Contractorss.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Not found Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Not found password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password entered incorrectly")]
        public string ConfirmPassword { get; set; }
    }
}
