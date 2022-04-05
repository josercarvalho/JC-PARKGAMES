using System;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using System.Linq;
using System.Data.Entity;

namespace JC_PARK.Infra.Data.Repositories
{
    public class RepositorioDePonto : RepositorioBase<Ponto>, IRepositorioDePonto
    {
        public Ponto BuscarUsuarioPorEvento(int usuario, int evento)
        {
            var query = (from u in _contexto.Ponto.Include(p => p.Eventos).Include(p => p.Usuarios)
                         where u.UsuarioId == usuario && u.EventoId == evento
                         select u).Single();
            return query;
        }

        public Ponto BuscarPonto(int usuario, int evento, DateTime dia)
        {
            //var dta = dia.ToShortDateString();
            var retorno = _contexto.Ponto.Where(p => p.UsuarioId == usuario && p.EventoId == evento && DbFunctions.TruncateTime(p.DataCadastro) == dia).FirstOrDefault();
            return retorno;
            ////return _contexto.Ponto.Where(p => p.UsuarioId == usuario && p.EventoId == evento && DbFunctions.TruncateTime(p.DataCadastro) == dia).FirstOrDefault();
        }
    }
}
