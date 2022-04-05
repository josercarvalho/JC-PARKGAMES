using System.Collections.Generic;
using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Aplication.Services
{
    public class AppServicoBase<TEntity> : IAppServicoBase<TEntity> where TEntity : class
    {
        private readonly IServicoBase<TEntity> _serviceBase;

        public AppServicoBase(IServicoBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public IEnumerable<TEntity> RecuperarTodos()
        {
            return _serviceBase.RecuperarTodos();
        }

        public TEntity RecuperarPorID(int id)
        {
            return _serviceBase.RecuperarPorID(id);
        }

        public void Inserir(TEntity obj)
        {
            _serviceBase.Inserir(obj);
        }

        public void Alterar(TEntity obj)
        {
            _serviceBase.Alterar(obj);
        }

        public void Remover(int id)
        {
            _serviceBase.Remover(id);
        }

        public void Remover(TEntity obj)
        {
            _serviceBase.Remover(obj);
        }
    }
}