using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JC_PARK.Domain.MetaData;

namespace JC_PARK.Domain.Entities
{
    [MetadataType(typeof(PerfilUsuarioMetaData))]
    public class PerfilUsuario 
    {
        public PerfilUsuario()
        {
            Usuarios = new List<Usuario>();
        }
        public int PerfilUsuarioId { get; set; }
        public string NomPerfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool FlAdminMaster { get; set; }
        public bool FlAtivo { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
