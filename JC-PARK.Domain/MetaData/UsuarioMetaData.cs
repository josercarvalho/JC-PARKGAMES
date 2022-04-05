using System;
using System.ComponentModel.DataAnnotations;

namespace JC_PARK.Domain.MetaData
{
    internal class UsuarioMetaData
    {
        public int UsuarioId { get; set; }

        [Required]
        [Display(Name = "Perfil Usuário")]
        public int PerfilUsuarioId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [MaxLength(50, ErrorMessage = "Máximo permitido para o Email são {0} caracteres.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Repita Nova Senha")]
        [Compare("Senha", ErrorMessage = "As senhas não se coincidem.")]
        public string SenhaKey { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }

        [Required]
        [Display(Name = "Contratação")]
        public Enum.TipoContrato TipoContrato { get; set; }

        //public IEnumerable<System.Web.Mvc.SelectListItem> ComboPerfilUsuario { get; set; }
    }
}
