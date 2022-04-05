using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JC_PARK.Domain.MetaData;

namespace JC_PARK.Domain.Entities
{
    [MetadataType(typeof(EventoMetaData))]
    public class Evento
    {
        public Evento()
        {
            ClienteLista = new List<Cliente>();
            UsuarioLista = new List<Usuario>();
            DespesaLista = new List<Despesa>();
            PontoLista = new List<Ponto>();
        }
        public int EventoId { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public decimal ValorPatio { get; set; }
        public virtual IEnumerable<Cliente> ClienteLista { get; set; }
        public virtual IEnumerable<Usuario> UsuarioLista { get; set; }
        public virtual IEnumerable<Despesa> DespesaLista { get; set; }
        public virtual IEnumerable<Ponto> PontoLista { get; set; }
    }
}
