using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JC_PARK.Domain.MetaData;

namespace JC_PARK.Domain.Entities
{
    [MetadataType(typeof(EmpresaMetaData))]
    public class Empresa
    {
        public int EmpresaId { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
