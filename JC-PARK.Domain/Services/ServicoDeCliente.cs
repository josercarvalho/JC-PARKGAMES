using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Domain.Services
{
    public class ServicoDeCliente : ServicoBase<Cliente>, IServicoDeCliente
    {
        private readonly IRepositorioDeClientes _repositorioDeClientes;
        public ServicoDeCliente(IRepositorioDeClientes repositorioDeClientes)
            : base(repositorioDeClientes)
        {
            _repositorioDeClientes = repositorioDeClientes;
        }

        public Cliente BuscaPorNome(string nome)
        {
            return _repositorioDeClientes.BuscaPorNome(nome);
        }
    }
}
