using System.ComponentModel.DataAnnotations;
using JC_PARK.Domain.MetaData;

namespace JC_PARK.Domain.Entities
{
    [MetadataType(typeof(ValoresMetaData))]
    public class Valores
    {
        public int ValoresId { get; set; }
        public int EventoId { get; set; }
        public int TipoValorId { get; set; }
        public decimal ValorNormal { get; set; }
        public decimal ValorEPorMinuto { get; set; }
        public decimal ValorEPorHora { get; set; }

        public virtual Evento Eventos { get; set; }
        public virtual TipoValor TipoValores { get; set; }
    }
}
