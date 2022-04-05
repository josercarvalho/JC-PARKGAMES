using System;
using System.ComponentModel.DataAnnotations;

namespace JC_PARK.Domain.MetaData
{
    internal class ClienteEventoMetadata
    {
        public int ClienteEventoId { get; set; }

        public int ClienteId { get; set; }

        [Display(Name = "Evento")]
        public int EventoId { get; set; }

        [Display(Name = "Data da Entrada")]
        //[DataType((DataType.Date))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }

        [Required]
        ////[DataType(DataType.Time)]
        [Display(Name = "Hora da Entrada")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH\\:mm\\:ss}")]
        //[RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)", ErrorMessage = "A hora deve ser entre 0:00 e 23:59")]
        public DateTime HoraEntrada { get; set; }

        [Required]
        //[DataType(DataType.Time)]
        [Display(Name = "Hora da Saída")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH\\:mm\\:ss}")]
        //[RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)", ErrorMessage = "A hora deve ser entre 0:00 e 23:59")]
        public DateTime HoraSaida { get; set; }

        public int Permanencia { get; set; }

        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Valor Excedente")]
        public decimal ValorExcedente { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Valor Total")]
        public decimal ValorTotal { get; set; }

        //[Required]
        //public string Foto { get; set; }

        public bool Ativo { get; set; }

        [Required]
        [Display(Name = "Pulseira")]
        public int EtiquetaId { get; set; }

    }
}
