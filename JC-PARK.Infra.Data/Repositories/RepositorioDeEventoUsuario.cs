using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace JC_PARK.Infra.Data.Repositories
{
    public class RepositorioDeEventoUsuario : RepositorioBase<EventoUsuario>, IRepositorioDeEventoUsuario
    {
        public void DesativaUsuario(int usuario, int evento)
        {
            var dados = _contexto.EventosUsuario.Where(u => u.UsuarioId == usuario && u.EventoId == evento).ToList();
            dados.ForEach(x => { x.Ativo = false; });
            _contexto.SaveChanges();
        }

        public EventoUsuario RecuperarPorUsuario(int usuario)
        {
            return _contexto.EventosUsuario.Include(e => e.EventosLista).Include(u => u.UsuarioLista).Where(p => p.UsuarioId == usuario && p.Ativo == true).Single();
        }

        public bool RemoverUsuario(int usuario, int evento)
        {
            var retorno = _contexto.EventosUsuario.Where(u => u.UsuarioId == usuario && u.EventoId == evento).FirstOrDefault();
            _contexto.EventosUsuario.Remove(retorno);
            _contexto.SaveChanges();
            return true;
        }
        public IEnumerable<EventoUsuario> BuscarEventos(int usuario)
        {
            return _contexto.EventosUsuario.Include(p => p.EventosLista).Include(p => p.UsuarioLista).Where(p => p.UsuarioId == usuario);
        }

        public IEnumerable<EventoUsuario> BuscarUsuarios(int evento)
        {
            return _contexto.EventosUsuario.Include(p => p.EventosLista).Where(p => p.EventoId == evento);
        }
    }
}
