using System.Collections.Generic;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Domain.Interfaces.Services
{
    public interface IServicoBase<TEntidade> where TEntidade : class
    {
        IEnumerable<TEntidade> RecuperarTodos();
        TEntidade RecuperarPorID(int id);
        void Inserir(TEntidade obj);
        void Alterar(TEntidade obj);
        void Remover(TEntidade obj);
        void Remover(int id);
    }
}
