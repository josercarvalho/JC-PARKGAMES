using System;
using System.Collections.Generic;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Domain.Services
{
    public class ServicoDeEventos : ServicoBase<Evento>, IServicoDeEventos
    {
        private readonly IRepositorioDeEventos _repositorioDeEventos;
        public ServicoDeEventos(IRepositorioDeEventos repositorioDeEventos) 
            : base(repositorioDeEventos)
        {
            _repositorioDeEventos = repositorioDeEventos;
        }

        public IEnumerable<Evento> BuscaPorDataEvento(DateTime dataDoEvento)
        {
            return _repositorioDeEventos.BuscaPorDataEvento(dataDoEvento);
        }

        public IEnumerable<Evento> BuscaPorLocalEvento(string localDoEvento)
        {
            return _repositorioDeEventos.BuscaPorLocalEvento(localDoEvento);
        }

        public void RemoveEvento(int evento)
        {
            _repositorioDeEventos.RemoveEvento(evento);
        }
    }
}
