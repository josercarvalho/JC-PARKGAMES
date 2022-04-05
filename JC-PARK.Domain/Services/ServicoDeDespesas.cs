using System;
using System.Collections.Generic;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Domain.Services
{
    public class ServicoDeDespesas : ServicoBase<Despesa>, IServicoDeDespesas
    {
        private readonly IRepositorioDeDespesas _repsitorioDeDespesas;
        public ServicoDeDespesas(IRepositorioDeDespesas repositorio) 
            : base(repositorio)
        {
            _repsitorioDeDespesas = repositorio;
        }

        public IEnumerable<Despesa> BuscaPorDatas(string dataInicial, string dataFinal)
        {
            return _repsitorioDeDespesas.BuscaPorDatas(dataInicial, dataFinal);
        }

        public IEnumerable<Despesa> BuscaPorEvento(int evento)
        {
            return _repsitorioDeDespesas.BuscaPorEvento(evento);
        }

        public IEnumerable<Despesa> BuscaPorMes(DateTime data)
        {
            return _repsitorioDeDespesas.BuscaPorMes(data);
        }
    }
}
