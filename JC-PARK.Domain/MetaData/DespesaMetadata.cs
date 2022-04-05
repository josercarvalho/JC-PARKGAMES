using System;
using System.ComponentModel.DataAnnotations;

namespace JC_PARK.Domain.MetaData
{
    public class DespesaMetadata
    {
        [Key]
        public int DespesaId { get; set; }

        [Required]
        [Display(Name = "Evento")]
        public int EventoId { get; set; }

        [Required]
        [Display(Name = "Lançamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }

        [Required]
        [Display(Name = "Valor Entrada")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal ValorEntrada { get; set; }

        [Required]
        [Display(Name = "Valor Despesas")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal ValorDespesa { get; set; }
    }
}
