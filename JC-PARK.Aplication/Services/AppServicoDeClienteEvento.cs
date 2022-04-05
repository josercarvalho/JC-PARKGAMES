using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using System.Collections.Generic;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Aplication.Services
{
    public class AppServicoDeClienteEvento : AppServicoBase<ClientesEvento>, IAppServicoDeClienteEvento
    {
        private readonly IServicoDeClienteEvento _servicoDeClienteEvento;
        public AppServicoDeClienteEvento(IServicoDeClienteEvento servicoDeClienteEvento) : base(servicoDeClienteEvento)
        {
            _servicoDeClienteEvento = servicoDeClienteEvento;
        }

        public bool BuscaEtiquetaAtiva(int etiqueta)
        {
            return _servicoDeClienteEvento.BuscaEtiquetaAtiva(etiqueta);
        }

        public ClientesEvento BuscaPorEtiqueta(int etiqueta)
        {
            return _servicoDeClienteEvento.BuscaPorEtiqueta(etiqueta);
        }

        public ClientesEvento BuscaPorEvento(int evento)
        {
            return _servicoDeClienteEvento.BuscaPorEvento(evento);
        }
    }
}
