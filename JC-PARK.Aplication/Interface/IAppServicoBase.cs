using System.Collections.Generic;

namespace JC_PARK.Aplication.Interface
{
    public interface IAppServicoBase<TEntidade> where TEntidade : class
    {
        IEnumerable<TEntidade> RecuperarTodos();
        TEntidade RecuperarPorID(int id);
        void Inserir(TEntidade obj);
        void Alterar(TEntidade obj);
        void Remover(TEntidade obj);
        void Remover(int id);
    }
}
