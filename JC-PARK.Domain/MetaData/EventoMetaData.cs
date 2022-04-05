using System;
using System.ComponentModel.DataAnnotations;

namespace JC_PARK.Domain.MetaData
{
    public class EventoMetaData
    {
        public int EventoId { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name ="Local")]
        public string Local { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }

        [Required]
        [Display(Name = "Data Inicial")]
        //[DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataInicial { get; set; }

        [Required]
        [Display(Name = "Data Final")]
        //[DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataFinal { get; set; }

        [Required]
        public string UF { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        [Display(Name = "Valor Pátio")]
        [DataType(DataType.Currency)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal ValorPatio { get; set; }

        //public IEnumerable<SelectListItem> ComboValorTipo { get; set; }

        //public IEnumerable<SelectListItem> ComboEvento { get; set; }

    }
}
