using System;
using System.ComponentModel.DataAnnotations;

namespace JC_PARK.Domain.MetaData
{
    internal class TipoValorMetaData
    {
        public int TipoValorId { get; set; }
        [Required]
        public string Nome { get; set; }
        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }
    }
}
