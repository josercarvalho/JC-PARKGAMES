using System.Web.Mvc;
using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;

namespace JC_PARK.Web.MVC.Controllers
{
    [Authorize]
    public class AtendimentoController : Controller
    {
        private readonly IAppServicoDeCliente _servicoDeCliente;
        private readonly IAppServicoDaEmpresa _servicoDaEmpresa;
        //private readonly IAppServicoDeValores _servicoDeValores;

        public AtendimentoController(IAppServicoDeCliente servicoDeCliente, IAppServicoDaEmpresa servicoDaEmpresa)
        {
            _servicoDeCliente = servicoDeCliente;
            _servicoDaEmpresa = servicoDaEmpresa;
            //_servicoDaValores = servicoDeValores;
        }

        [Authorize]
        // GET: Atendimento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Saida()
        {
            //ViewBag.empresa = SessionManager.UsuarioLogado.Evento.Nome;
            return View();
        }

        [HttpPost]

        public ActionResult Saida(Cliente cliente)
        {
            if (!ModelState.IsValid) return View(cliente);
            _servicoDeCliente.Alterar(cliente);
            return RedirectToAction("Saida");
        }

        
    }
}