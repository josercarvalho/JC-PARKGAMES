using JC_PARK.Domain.Entities;
using System;
using System.Collections.Generic;

namespace JC_PARK.Domain.Interfaces.Services
{
    public interface IServicoDePonto : IServicoBase<Ponto>
    {
        Ponto BuscarUsuarioPorEvento(int usuario, int evento);

        Ponto BuscarPonto(int usuario, int evento, DateTime dia);
    }
}
