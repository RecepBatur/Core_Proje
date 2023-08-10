using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Zorunlu alan")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi girin")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi girin")]
        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Lütfen mail adresinizi girin")]
        public string Email { get; set; }

    }
}
