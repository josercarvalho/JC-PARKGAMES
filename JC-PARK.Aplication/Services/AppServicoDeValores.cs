using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace JC_PARK.Aplication.Services
{
    public class AppServicoDeValores : AppServicoBase<Valores>, IAppServicoDeValores
    {
        private readonly IServicoDeValores _servicoDeValores;
        public AppServicoDeValores(IServicoDeValores servicoDeValores)
            : base(servicoDeValores)
        {
            _servicoDeValores = servicoDeValores;
        }

        public Valores BuscarPorEvento(int evento)
        {
            return _servicoDeValores.BuscarPorEvento(evento);
        }

        public IEnumerable<Valores> BuscarTodos()
        {
            return _servicoDeValores.BuscarTodos();
        }
    }
}
