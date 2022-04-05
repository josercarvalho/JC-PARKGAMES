using JC_PARK.Domain.Entities;
using System.Collections.Generic;

namespace JC_PARK.Aplication.Interface
{
    public interface IAppServicoDeValores : IAppServicoBase<Valores>
    {
        Valores BuscarPorEvento(int evento);
        IEnumerable<Valores> BuscarTodos();
    }
}
