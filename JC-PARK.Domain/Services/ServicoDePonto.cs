using System;
using System.Collections.Generic;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Domain.Services
{
    public class ServicoDePonto : ServicoBase<Ponto>, IServicoDePonto
    {
        private readonly IRepositorioDePonto _servicoDePonto;
        public ServicoDePonto(IRepositorioDePonto repositorio) : base(repositorio)
        {
            _servicoDePonto = repositorio;
        }

        public Ponto BuscarUsuarioPorEvento(int usuario, int evento)
        {
            return _servicoDePonto.BuscarUsuarioPorEvento(usuario, evento);
        }

        public Ponto BuscarPonto(int usuario, int evento, DateTime dia)
        {
            return _servicoDePonto.BuscarPonto(usuario, evento, dia);
        }
    }
}
