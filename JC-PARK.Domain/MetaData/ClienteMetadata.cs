using System;
using System.ComponentModel.DataAnnotations;

namespace JC_PARK.Domain.MetaData
{
    internal class ClienteMetadata
    {
        public int ClienteId { get; set; }

        [Required]
        [Display(Name = "Nome da Criança")]
        public string NomeCrianca { get; set; }

        [Required]
        [Display(Name = "Nome do Pai")]
        public string NomePai { get; set; }

        [Required]
        [Display(Name = "Fone do Pai")]
        public string TelefonePai { get; set; }

        [Required]
        [Display(Name = "Nome da Mãe")]
        public string NomeMae { get; set; }

        [Required]
        [Display(Name = "Fone da Mãe")]
        public string TelefoneMae { get; set; }

        [Required]
        [Display(Name = "Responsável")]
        public string NomeResponsavel { get; set; }

        [Required]
        [Display(Name = "Fone Respons.")]
        public string FeneResponsavel { get; set; }

        [Required]
        [Display(Name = "Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? Nascimento { get; set; }

        [Required]
        public Enum.Sexo? Sexo { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Data Cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? DataCadastro { get; set; }
    }
}
