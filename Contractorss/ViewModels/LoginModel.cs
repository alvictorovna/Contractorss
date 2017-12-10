using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Contractorss.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Not found Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Not found password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
