using System.Web;
using System.Web.Mvc;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Web.MVC.Util
{
    [Authorize]
    public class SessionManager
    {
        public static Usuario UsuarioLogado
        {
            set
            {

                HttpContext.Current.Session.Add("UsuarioLogado", value);
            }
            get
            {
                return (Usuario)HttpContext.Current.Session["UsuarioLogado"];
            }

        }

        public static bool IsAuthenticated
        {
            get
            {
                return ((Usuario)HttpContext.Current.Session["UsuarioLogado"]) != null;
            }
        }
    }
}