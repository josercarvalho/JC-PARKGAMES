using System;
using System.ComponentModel.DataAnnotations;

namespace JC_PARK.Domain.MetaData
{
    internal class PerfilUsuarioMetaData
    {
        public int PerfilUsuarioId { get; set; }
        [Required]
        public string NomPerfil { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }
        public bool FlAdminMaster { get; set; }
        public bool FlAtivo { get; set; }
    }
}
