using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Services;
using JC_PARK.Domain.Services;
using System;
using System.Collections.Generic;

namespace JC_PARK.Aplication.Services
{
    public class AppServicoDeDespesa : AppServicoBase<Despesa>, IAppServicoDeDespesa
    {
        private readonly IServicoDeDespesas _servicoDeDespesa;
        public AppServicoDeDespesa(IServicoDeDespesas servicoDeDespesa) : base(servicoDeDespesa)
        {
            _servicoDeDespesa = servicoDeDespesa;
        }

        public IEnumerable<Despesa> BuscaPorDatas(string dataInicial, string dataFinal)
        {
            return _servicoDeDespesa.BuscaPorDatas(dataInicial, dataFinal);
        }

        public IEnumerable<Despesa> BuscaPorEvento(int evento)
        {
            return _servicoDeDespesa.BuscaPorEvento(evento);
        }

        public IEnumerable<Despesa> BuscaPorMes(DateTime data)
        {
            return _servicoDeDespesa.BuscaPorMes(data);
        }
    }
}
