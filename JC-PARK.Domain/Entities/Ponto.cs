using JC_PARK.Domain.MetaData;
using System;
using System.ComponentModel.DataAnnotations;

namespace JC_PARK.Domain.Entities
{
    [MetadataType(typeof(PontoMetaData))]
    public class Ponto
    {
        public int PontoId { get; set; }
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public virtual Usuario Usuarios { get; set; }
        public virtual Evento Eventos { get; set; }
    }
}