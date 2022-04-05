using System;
using System.ComponentModel.DataAnnotations;

namespace JC_PARK.Web.MVC.ViewModels
{
    public class DespesaVM
    {
        public int EventoId { get; set; }

        [Display(Name = "Lançamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Valor Entrada")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal ValorEntrada { get; set; }

        [Display(Name = "Desconto Pátio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal DescontoPatio { get; set; }

        [Display(Name = "Valor Despesas")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal ValorDespesa { get; set; }

        [Display(Name = "Valor Dia")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal TotalDia { get; set; }
    }
}