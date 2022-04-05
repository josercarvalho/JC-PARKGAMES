using JC_PARK.Infra.Data.Contexto;
using JC_PARK.Domain.Interfaces.Infra;
using Microsoft.Practices.ServiceLocation;

namespace JC_PARK.Infra.Data.EntityConfig
{
    public class UnidadeDeTrabalhoEF : IUnidadeDeTrabalho
    {
        private ContextoBanco _contexto;

        public void Iniciar()
        {
            var gerenciador = ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorio>()
                              as GerenciadorDeRepositorio;

            if (gerenciador != null) _contexto = gerenciador.Contexto;
        }

        public void Persistir()
        {
            _contexto.SaveChanges();
        }
    }
}
