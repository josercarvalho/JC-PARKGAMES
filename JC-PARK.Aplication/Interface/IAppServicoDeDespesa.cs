using JC_PARK.Domain.Entities;
using System;
using System.Collections.Generic;

namespace JC_PARK.Aplication.Interface
{
    public interface IAppServicoDeDespesa : IAppServicoBase<Despesa>
    {
        IEnumerable<Despesa> BuscaPorDatas(string dataInicial, string dataFinal);
        IEnumerable<Despesa> BuscaPorEvento(int evento);
        IEnumerable<Despesa> BuscaPorMes(DateTime data);
    }
}
