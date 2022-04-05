using System;
using System.Collections.Generic;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Domain.Interfaces.Services
{
    public interface IServicoDeEventos : IServicoBase<Evento>
    {
        IEnumerable<Evento> BuscaPorDataEvento(DateTime dataDoEvento);
        IEnumerable<Evento> BuscaPorLocalEvento(string localDoEvento);
        void RemoveEvento(int evento);
    }
}
