using System;
using System.Collections.Generic;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Domain.Interfaces.Repositories
{
    public interface IRepositorioDeEventos : IRepositorioBase<Evento>
    {
        IEnumerable<Evento> BuscaPorDataEvento(DateTime dataDoEvento);
        IEnumerable<Evento> BuscaPorLocalEvento(string localDoEvento);
        void RemoveEvento(int evento);
    }
}
