using System;
using System.ComponentModel.DataAnnotations;

namespace JC_PARK.Domain.MetaData
{
    public class PontoMetaData
    {
        public int PontoId { get; set; }

        [Required]
        [Display(Name ="Usuário")]
        public int UsuarioId { get; set; }

        [Required]
        [Display(Name ="Evento")]
        public int EventoId { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }

        [Required]
        [Display(Name = "Hora da Entrada")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH\\:mm\\:ss}")]
        public DateTime HoraEntrada { get; set; }

        [Required]
        [Display(Name = "Hora da Saída")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH\\:mm\\:ss}")]
        public DateTime HoraSaida { get; set; }
    }
}
