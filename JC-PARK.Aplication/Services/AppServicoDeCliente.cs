using System;
using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Aplication.Services
{
    public class AppServicoDeCliente : AppServicoBase<Cliente>, IAppServicoDeCliente
    {
        private readonly IServicoDeCliente _servicoDeCliente;
        public AppServicoDeCliente(IServicoDeCliente servicoDeCliente) : base(servicoDeCliente)
        {
            _servicoDeCliente = servicoDeCliente;
        }

        public Cliente BuscaPorNome(string nome)
        {
            return _servicoDeCliente.BuscaPorNome(nome);
        }
    }
}
