using JC_PARK.Domain.Entities;
using System.Collections.Generic;

namespace JC_PARK.Domain.Interfaces.Services
{
    public interface IServicoDeValores : IServicoBase<Valores>
    {
        Valores BuscarPorEvento(int evento);
        IEnumerable<Valores> BuscarTodos();
    }
}
