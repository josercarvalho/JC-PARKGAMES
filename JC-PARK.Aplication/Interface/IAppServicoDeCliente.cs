using JC_PARK.Domain.Entities;

namespace JC_PARK.Aplication.Interface
{
    public interface IAppServicoDeCliente : IAppServicoBase<Cliente>
    {
        Cliente BuscaPorNome(string nome);
    }
}
