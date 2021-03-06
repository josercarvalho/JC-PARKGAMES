using System.ComponentModel.DataAnnotations;

namespace JC_PARK.Web.MVC.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        //[MaxLength(30, ErrorMessage = "Máximo permitido para o Email são 30 caracteres.")]
        [EmailAddress]
        public string Email { get; set; }

        public int Evento { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Esqueci minha senha.")]
        public bool RememberMe { get; set; }
    }
}