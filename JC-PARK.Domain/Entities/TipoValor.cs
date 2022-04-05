using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JC_PARK.Domain.MetaData;

namespace JC_PARK.Domain.Entities
{
    [MetadataType(typeof(TipoValorMetaData))]
    public class TipoValor
    {
        public TipoValor()
        {
            Valor = new List<Valores>();
        }

        public int TipoValorId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<Valores> Valor { get; set; }

    }
}
