using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using System.Linq;
using System;

namespace JC_PARK.Infra.Data.Repositories
{
    public class RepositorioDeClienteEvento : RepositorioBase<ClientesEvento>, IRepositorioDeClienteEvento
    {

        public bool BuscaEtiquetaAtiva(int etiqueta)
        {
            var etiquetaAtiva = _contexto.ClientesEvento.FirstOrDefault(e => e.EtiquetaId == etiqueta);
            var retorno = etiquetaAtiva != null && etiquetaAtiva.Ativo;

            return retorno;
        }
        public ClientesEvento BuscaPorEtiqueta(int etiqueta)
        {
            throw new NotImplementedException();
        }

        public ClientesEvento BuscaPorEvento(int evento)
        {
            return _contexto.ClientesEvento.Include("Cliente").Include("Evento").Include("Usuario").Where(c => c.EventoId == evento).Single();
        }
    }
}
