using System;
using System.ComponentModel.DataAnnotations;
using JC_PARK.Domain.MetaData;

namespace JC_PARK.Domain.Entities
{
    [MetadataType(typeof(ClienteEventoMetadata))]
    public class ClientesEvento
    {
        public int ClienteEventoId { get; set; }
        public int ClienteId { get; set; }
        public int EventoId { get; set; }
        public int EtiquetaId { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public int Permanencia { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorExcedente { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Ativo { get; set; }

        public virtual Evento Evento { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
