using System.ComponentModel.DataAnnotations;

namespace PIM3.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "\nDigite o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "\nDigite a senha")]
        public string Senha { get; set; }
    }
}
