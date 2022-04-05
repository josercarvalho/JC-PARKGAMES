using System;
using System.ComponentModel.DataAnnotations;
using JC_PARK.Domain.MetaData;
using System.Collections.Generic;

namespace JC_PARK.Domain.Entities
{
    [MetadataType(typeof(ClienteMetadata))]
    public class Cliente
    {
        public Cliente()
        {
            ListaEventos = new List<ClientesEvento>();
        }
        public int ClienteId { get; set; }
        public string NomeCrianca { get; set; }
        public string NomePai { get; set; }
        public string TelefonePai { get; set; }
        public string NomeMae { get; set; }
        public string TelefoneMae { get; set; }
        public string NomeResponsavel { get; set; }
        public string FeneResponsavel { get; set; }
        public DateTime Nascimento { get; set; }
        public Enum.Sexo Sexo { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Foto { get; set; }
        public virtual List<ClientesEvento> ListaEventos { get; private set; }

        //public void ChecarCliente()
        //{
        //    var mensagem = new List<string>();

        //    if (string.IsNullOrEmpty(NomeCrianca) || NomeCrianca.Trim().Length == 0)
        //        mensagem.Add("Nome inválido");

        //    if (Nascimento == new DateTime())
        //        mensagem.Add("Nascimento inválido");

        //    if (mensagem.Count > 0)
        //        throw new Exception(string.Join(" | ", mensagem));
        //}
    }
}
