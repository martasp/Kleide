using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kleide.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Prisijungimo vardas?")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Slaptažodis?")]
        public string Password { get; set; }

        [Display(Name = "Įsiminti?")]
        public bool RememberMe { get; set; }
    }
}
