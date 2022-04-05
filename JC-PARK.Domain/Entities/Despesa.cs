using System;

namespace JC_PARK.Domain.Entities
{
    public class Despesa
    {
        public int DespesaId { get; set; }
        public int EventoId { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal ValorEntrada { get; set; }
        public decimal ValorDespesa { get; set; }

        public virtual Evento Eventos { get; set; }
    }
}
