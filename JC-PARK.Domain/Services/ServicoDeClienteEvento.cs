using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using JC_PARK.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace JC_PARK.Domain.Services
{
    public class ServicoDeClienteEvento : ServicoBase<ClientesEvento>, IServicoDeClienteEvento
    {
        private readonly IRepositorioDeClienteEvento _repositorioClienteEvento;

        public ServicoDeClienteEvento(IRepositorioDeClienteEvento repositorioClienteEvento) : base(repositorioClienteEvento)
        {
            _repositorioClienteEvento = repositorioClienteEvento;
        }

        public bool BuscaEtiquetaAtiva(int etiqueta)
        {
            return _repositorioClienteEvento.BuscaEtiquetaAtiva(etiqueta);
        }

        public ClientesEvento BuscaPorEtiqueta(int etiqueta)
        {
            return _repositorioClienteEvento.BuscaPorEtiqueta(etiqueta);
        }

        public ClientesEvento BuscaPorEvento(int evento)
        {
            return _repositorioClienteEvento.BuscaPorEvento(evento);
        }
    }
}
