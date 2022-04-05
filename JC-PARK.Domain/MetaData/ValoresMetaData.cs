using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace JC_PARK.Domain.MetaData
{
    internal class ValoresMetaData
    {
        [Key]
        public int ValoresId { get; set; }

        [Required]
        [Display(Name = "Evento")]
        public int EventoId { get; set; }

        [Required]
        [Display(Name = "Tipo do Valor")]
        public int TipoValorId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        //[Range(typeof(decimal), "0", "999999999999")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [Display(Name = "Valor Normal")]
        public decimal ValorNormal { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        //[Range(typeof(decimal), "0", "999999999999")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [Display(Name = "Excedente por minuto")]
        public decimal ValorEPorMinuto { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        //[Range(typeof(decimal), "0", "999999999999")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [Display(Name = "Excedente por hora")]
        public decimal ValorEPorHora { get; set; }
    }
}
