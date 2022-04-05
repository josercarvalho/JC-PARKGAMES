using JC_PARK.Domain.Entities;
using System.Collections.Generic;

namespace JC_PARK.Domain.Interfaces.Services
{
    public interface IServicoDeClienteEvento : IServicoBase<ClientesEvento>
    {
        ClientesEvento BuscaPorEvento(int evento);
        ClientesEvento BuscaPorEtiqueta(int etiqueta);
        bool BuscaEtiquetaAtiva(int etiqueta);
    }
}
