using System.Linq;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using System.Data.Entity;
using System.Collections.Generic;

namespace JC_PARK.Infra.Data.Repositories
{
    public class RepositorioDeValores : RepositorioBase<Valores>, IRepositorioDeValores
    {
        public Valores BuscarPorEvento(int evento)
        {
            return _contexto.Valores.FirstOrDefault(v => v.EventoId == evento);
        }

        public IEnumerable<Valores> BuscarTodos()
        {
            yield return _contexto.Valores.Include(e => e.Eventos).Include(p => p.TipoValores).Single();
        }
    }
}
