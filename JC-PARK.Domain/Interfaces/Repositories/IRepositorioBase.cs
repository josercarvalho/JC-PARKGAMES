using System.Collections.Generic;

namespace JC_PARK.Domain.Interfaces.Repositories
{
    public interface IRepositorioBase<TEntidade> where TEntidade : class
    {
        IEnumerable<TEntidade> RecuperarTodos();
        TEntidade RecuperarPorID(int id);
        void Inserir(TEntidade obj);
        void Alterar(TEntidade obj);
        void Remover(TEntidade obj);
        void Remover(int id);
    }
}
