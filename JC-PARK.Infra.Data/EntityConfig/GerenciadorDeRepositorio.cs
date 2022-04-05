using System.Web;
using JC_PARK.Infra.Data.Contexto;
using JC_PARK.Domain.Interfaces.Infra;

namespace JC_PARK.Infra.Data.EntityConfig
{
    public class GerenciadorDeRepositorio : IGerenciadorDeRepositorio
    {
        public const string ContextoHttp = "ContextoHttp";

        public ContextoBanco Contexto
        {
            get
            {
                if (HttpContext.Current.Items[ContextoHttp] == null)
                    HttpContext.Current.Items[ContextoHttp] = new ContextoBanco();
                return HttpContext.Current.Items[ContextoHttp] as ContextoBanco;
            }
        }

        public void Finalizar()
        {
            if (HttpContext.Current.Items[ContextoHttp] != null)
            {
                var contextoBanco = HttpContext.Current.Items[ContextoHttp] as ContextoBanco;
                if (contextoBanco != null)
                    contextoBanco.Dispose();
            }
        }
    }
}
