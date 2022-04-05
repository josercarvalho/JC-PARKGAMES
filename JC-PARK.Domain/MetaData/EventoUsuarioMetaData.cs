using JC_PARK.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace JC_PARK.Domain.MetaData
{
    internal class EventoUsuarioMetaData
    {
        public int EventoUsuarioId { get; set; }

        [Required]
        [Display(Name ="Funcionário")]
        public string UsuarioNome { get; set; }

        [Required]
        [Display(Name ="Evento")]
        public int EventoId { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Data Cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }

        [Required]
        [Display(Name = "Hora da Entrada")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH\\:mm\\:ss}")]
        public DateTime HoraEntrada { get; set; }

        [Required]
        [Display(Name ="Hora da Saída")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH\\:mm\\:ss}")]
        public DateTime HoraSaida { get; set; }

    }
}
