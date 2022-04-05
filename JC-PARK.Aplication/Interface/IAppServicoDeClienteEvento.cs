using JC_PARK.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JC_PARK.Aplication.Interface
{
    public interface IAppServicoDeClienteEvento : IAppServicoBase<ClientesEvento>
    {
        ClientesEvento BuscaPorEvento(int evento);
        ClientesEvento BuscaPorEtiqueta(int etiqueta);
        bool BuscaEtiquetaAtiva(int etiqueta);
    }
}
