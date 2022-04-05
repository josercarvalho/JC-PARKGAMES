using System;
using System.ComponentModel.DataAnnotations;

namespace JC_PARK.Domain.MetaData
{
    internal class ModulosAcessoMetaData
    {
        [Required]
        public int ModuloId { get; set; }
        [Required]
        public string NomeModulo { get; set; }
        [Required]
        public string NomeMenuAcesso { get; set; }
        [Required]
        public string UrlMenu { get; set; }
        public bool FlAtivo { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }
        public int? ModuloPaiId { get; set; }
    }
}
