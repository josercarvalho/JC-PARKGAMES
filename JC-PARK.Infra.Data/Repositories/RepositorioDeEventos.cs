using System;
using System.Collections.Generic;
using System.Linq;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;

namespace JC_PARK.Infra.Data.Repositories
{
    public class RepositorioDeEventos : RepositorioBase<Evento>, IRepositorioDeEventos
    {
        public IEnumerable<Evento> BuscaPorDataEvento(DateTime dataDoEvento)
        {
            return _contexto.Eventos.Where(e => e.DataInicial.Date == dataDoEvento.Date);
        }

        public IEnumerable<Evento> BuscaPorLocalEvento(string localDoEvento)
        {
            return _contexto.Eventos.Where(e => e.Local == localDoEvento);
        }

        public void RemoveEvento(int evento)
        {
            var query = _contexto.EventosUsuario.Where(p => p.EventoId == evento);
            _contexto.EventosUsuario.RemoveRange(query);

            var retorno = _contexto.EventosUsuario.Find(evento);
            _contexto.EventosUsuario.Remove(retorno);
        }
    }
}
