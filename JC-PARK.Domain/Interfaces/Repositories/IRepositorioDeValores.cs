using JC_PARK.Domain.Entities;
using System.Collections.Generic;

namespace JC_PARK.Domain.Interfaces.Repositories
{
    public interface IRepositorioDeValores : IRepositorioBase<Valores>
    {
        Valores BuscarPorEvento(int evento);
        IEnumerable<Valores> BuscarTodos();
    }
}
