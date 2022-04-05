using System.Collections.Generic;
using JC_PARK.Domain.Interfaces.Repositories;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Domain.Services
{
    public class ServicoBase<TEntidade> : IServicoBase<TEntidade> where TEntidade : class
    {
        private readonly IRepositorioBase<TEntidade> _repositorio;

        public ServicoBase(IRepositorioBase<TEntidade> repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<TEntidade> RecuperarTodos()
        {
            return _repositorio.RecuperarTodos();
        }

        public TEntidade RecuperarPorID(int id)
        {
            return _repositorio.RecuperarPorID(id);
        }

        public void Inserir(TEntidade obj)
        {
            _repositorio.Inserir(obj);
        }

        public void Alterar(TEntidade obj)
        {
            _repositorio.Alterar(obj);
        }

        public void Remover(TEntidade obj)
        {
            _repositorio.Remover(obj);
        }

        public void Remover(int id)
        {
            var resultado = _repositorio.RecuperarPorID(id);
            Remover(resultado);
        }
    }
}
