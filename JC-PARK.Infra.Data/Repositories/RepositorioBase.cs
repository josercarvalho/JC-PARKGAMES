using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using JC_PARK.Infra.Data.Contexto;
using JC_PARK.Infra.Data.EntityConfig;
using JC_PARK.Domain.Interfaces.Infra;
using JC_PARK.Domain.Interfaces.Repositories;
using Microsoft.Practices.ServiceLocation;
using System;

namespace JC_PARK.Infra.Data.Repositories
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : class
    {
        protected readonly ContextoBanco _contexto;

        public RepositorioBase()
        {
            var gerenciador = (GerenciadorDeRepositorio)ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorio>();
            _contexto = gerenciador.Contexto;
        }

        public void Alterar(TEntidade obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;
            _contexto.SaveChanges();
        }


        public void Inserir(TEntidade obj)
        {
            _contexto.Set<TEntidade>().Add(obj);
            _contexto.SaveChanges();
        }

        public TEntidade RecuperarPorID(int id)
        {
            return _contexto.Set<TEntidade>().Find(id);
        }

        public IEnumerable<TEntidade> RecuperarTodos()
        {
            return _contexto.Set<TEntidade>().ToList();
        }

        public void Remover(int id)
        {
            TEntidade obj = RecuperarPorID(id);
            Remover(obj);
        }

        public void Remover(TEntidade obj)
        {
            _contexto.Set<TEntidade>().Remove(obj);
            _contexto.SaveChanges();
        }
    }
}
