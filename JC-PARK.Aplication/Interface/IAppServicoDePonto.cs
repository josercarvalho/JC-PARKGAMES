using JC_PARK.Domain.Entities;
using System;
using System.Collections.Generic;

namespace JC_PARK.Aplication.Interface
{
    public interface IAppServicoDePonto : IAppServicoBase<Ponto>
    {
        Ponto BuscarUsuarioPorEvento(int usuario, int evento);
        Ponto BuscarPonto(int usuario, int evento, DateTime dia);
        void BaterPonto(int usuario, int evento);
        bool ChecaSaida(int usuario, int evento, DateTime hora);
    }
}
