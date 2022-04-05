using System;
using System.ComponentModel.DataAnnotations;

namespace JC_PARK.Domain.MetaData
{
    internal class EmpresaMetaData
    {
        public int EmpresaId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Local { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string UF { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name ="Data Cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }

        //[Required]
        //[Display(Name = "Máscara da Etiqueta")]
        //public int Mascara { get; set; }
    }
}
