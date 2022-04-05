using System;
using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Services;
using System.Collections.Generic;


namespace JC_PARK.Aplication.Services
{
    public class AppServicoDeEventos : AppServicoBase<Evento>, IAppServicoDeEventos
    {
        private readonly IServicoDeEventos _servicoDeEventos;
        public AppServicoDeEventos(IServicoBase<Evento> serviceBase, IServicoDeEventos servicoDeEventos) 
            : base(serviceBase)
        {
            _servicoDeEventos = servicoDeEventos;
        }

        public IEnumerable<Evento> BuscaPorDataEvento(DateTime dataDoEvento)
        {
            return _servicoDeEventos.BuscaPorDataEvento(dataDoEvento);
        }

        public IEnumerable<Evento> BuscaPorLocalEvento(string localDoEvento)
        {
            return _servicoDeEventos.BuscaPorLocalEvento(localDoEvento);
        }

        public void RemoveEvento(int evento)
        {
            _servicoDeEventos.RemoveEvento(evento);
        }
    }
}
