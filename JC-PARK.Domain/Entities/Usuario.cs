using System;
using System.ComponentModel.DataAnnotations;
using JC_PARK.Domain.MetaData;
using System.Collections.Generic;

namespace JC_PARK.Domain.Entities
{
	[MetadataType(typeof(UsuarioMetaData))]
	public class Usuario
	{
		public int UsuarioId { get; set; }
		public int PerfilUsuarioId { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
		public string SenhaKey { get; set; }
		public DateTime DataCadastro { get; set; }
		public Enum.TipoContrato TipoContrato { get; set; }
		public decimal Salario { get; set; }
		public bool Ativo { get; set; }

		public virtual PerfilUsuario PerfilUsuario { get; set; }
	}

}