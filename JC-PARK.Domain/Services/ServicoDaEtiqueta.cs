using System.Linq;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Domain.Services
{
    public class ServicoDaEtiqueta : ServicoBase<Etiqueta>, IServicoDaEtiqueta
    {
        private readonly IRepositorioDeEtiqueta _repositorioDeEtiqueta;

        public ServicoDaEtiqueta(IRepositorioDeEtiqueta repositorioDeEtiqueta)
            : base(repositorioDeEtiqueta)
        {
            _repositorioDeEtiqueta = repositorioDeEtiqueta;
        }

        public IOrderedEnumerable<Etiqueta> PegaUltimaEtiquera()
        {
            IOrderedEnumerable<Etiqueta> resultado = _repositorioDeEtiqueta.RecuperarTodos().OrderByDescending(e => e.NumeroAtual);
            return resultado;
        }
    }
}
