using System;
using System.Collections.Generic;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Aplication.Interface
{
    public interface IAppServicoDeEventos : IAppServicoBase<Evento>
    {
        IEnumerable<Evento> BuscaPorDataEvento(DateTime dataDoEvento);
        IEnumerable<Evento> BuscaPorLocalEvento(string localDoEvento);
        void RemoveEvento(int evento);
    }
}
