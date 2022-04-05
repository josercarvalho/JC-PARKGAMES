using JC_PARK.Domain.MetaData;
using System;
using System.ComponentModel.DataAnnotations;

namespace JC_PARK.Domain.Entities
{
    [MetadataType(typeof(EventoUsuarioMetaData))]
    public class EventoUsuario
    {
        public int EventoUsuarioId { get; set; }
        public int EventoId { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public bool Ativo { get; set; }

        public virtual Evento EventosLista { get; set; }
        public virtual Usuario UsuarioLista { get; set; }
    }
}
