using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JC_PARK.Domain.MetaData
{
    internal class EtiquetaMetaData
    {
        public int EtiquetaId { get; set; }

        //[Required]
        //[Display(Name = "Evento")]
        //public int EventoId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DisplayName("Data Geração")]
        public DateTime DataCadastro { get; set; }

        [Required]
        [DisplayName("Número Atual")]
        public int NumeroAtual { get; set; }

        [Required]
        [DisplayName("Quantidade a imprimir")]
        public int Quantidade { get; set; }
    }
}
