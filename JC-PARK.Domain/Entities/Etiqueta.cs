using System;
using System.ComponentModel.DataAnnotations;
using JC_PARK.Domain.MetaData;

namespace JC_PARK.Domain.Entities
{
	[MetadataType(typeof(EtiquetaMetaData))]
	public class Etiqueta
	{
		public int EtiquetaId { get; set; }
		//public int EventoId { get; set; }
		public DateTime DataCadastro { get; set; }
		public int NumeroAtual { get; set; }
		public int Quantidade { get; set; }

		//public virtual Evento Evento { get; set; }
	}
}
