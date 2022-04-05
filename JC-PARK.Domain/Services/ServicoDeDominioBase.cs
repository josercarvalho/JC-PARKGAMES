using JC_PARK.Domain.Interfaces.Infra;
using Microsoft.Practices.ServiceLocation;

namespace JC_PARK.Domain.Services
{
    public class ServicoDeDominioBase
    {
        private IUnidadeDeTrabalho _unidadeDeTrabalho;

        public virtual void IniciarTransação()
        {
            _unidadeDeTrabalho = ServiceLocator.Current.GetInstance<IUnidadeDeTrabalho>();
            _unidadeDeTrabalho.Iniciar();
        }

        public virtual void PersistirTransação()
        {
            _unidadeDeTrabalho.Persistir();
        }
    }
}
