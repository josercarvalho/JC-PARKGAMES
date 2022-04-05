using System;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using JC_PARK.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace JC_PARK.Domain.Services
{
    public class ServicoDeValores : ServicoBase<Valores>, IServicoDeValores
    {
        private readonly IRepositorioDeValores _repositorioDeValores;
        public ServicoDeValores(IRepositorioDeValores repositorioDeValores)
            : base(repositorioDeValores)
        {
            _repositorioDeValores = repositorioDeValores;
        }

        public Valores BuscarPorEvento(int evento)
        {
            return _repositorioDeValores.BuscarPorEvento(evento);
        }

        public IEnumerable<Valores> BuscarTodos()
        {
            return _repositorioDeValores.BuscarTodos();
        }
    }
}
