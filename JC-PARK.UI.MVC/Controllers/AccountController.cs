using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using JC_PARK.Aplication.Interface;
using JC_PARK.Web.MVC.Util;
using JC_PARK.Web.MVC.ViewModels;
using System.Globalization;

namespace JC_PARK.Web.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppServicoDeUsuario _servicoDeUsuario;
        private readonly IAppServicoDeEventoUsuario _servicoDeEventoUsuario;

        public AccountController(IAppServicoDeUsuario servicoDeUsuario, IAppServicoDeEventoUsuario servicoDeEventoUsuario)
        {
            _servicoDeUsuario = servicoDeUsuario;
            _servicoDeEventoUsuario = servicoDeEventoUsuario;
        }

        #region Dados do LOGIN

        // GET: Account/Login
        public ActionResult Login()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            Session.Abandon();
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            if (viewModel.Evento < 1)
            {
                ModelState.AddModelError("Evento", "Evento não informado. Obrigatório!");
                return View(viewModel);
            }

            var usuario = _servicoDeUsuario.LogaUsuario(viewModel.Email, viewModel.Password);
            if (usuario == null)
            {
                ModelState.AddModelError("", "Email ou Senha incorretos.");
                return View(viewModel);
            }

            //Irá setar um cookie encriptado com o Login do usuário autenticado
            FormsAuthentication.SetAuthCookie(usuario.Nome, false);

            //Sessão para uso de menus e redirecionamento do Sistema
            SessionManager.UsuarioLogado = usuario;

            //Direciona para o módulo mediante tipo de usuário já incluindo qual empresa irá exercer operação
            return RedirectToAction("Index", SessionManager.UsuarioLogado.PerfilUsuarioId != 3 ? "Home" : "Atendimento");
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.RemoveAll();

            ModelState.AddModelError("", "Usuário desconectado com sucesso.");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            var viewModel = new RegisterViewModel
            {
                ComboPerfilUsuario =
                    _servicoDeUsuario.RecuperaTodosPerfisAtivos()
                        .Select(
                            x => new SelectListItem { Text = x.NomPerfil, Value = Convert.ToString(x.PerfilUsuarioId) })
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            viewModel.ComboPerfilUsuario = _servicoDeUsuario.RecuperaTodosPerfisAtivos().Select(x => new SelectListItem { Text = x.NomPerfil, Value = Convert.ToString(x.PerfilUsuarioId) });

            var usuarioExistente = _servicoDeUsuario.RecuperaUsuarioPorEmail(viewModel.Email);
            if (usuarioExistente != null)
            {
                ModelState.AddModelError("", "Email já está sendo utilizado.");
                return View(viewModel);
            }

            _servicoDeUsuario.CadastraUsuario(
                new Domain.Entities.Usuario
                {
                    Nome = viewModel.Nome,
                    DataCadastro = DateTime.Now,
                    Email = viewModel.Email,
                    PerfilUsuarioId = viewModel.PerfilUsuarioId,
                    Senha = viewModel.Senha,
                    SenhaKey = viewModel.Senha // Functions.GetRandomString()
                });

            //var usuario = _servicoDeUsuario.LogaUsuario(viewModel.Email, viewModel.Senha);
            //if (usuario == null)
            //{
            //    ModelState.AddModelError("", "Email ou Senha incorretos.");
            //    return View(viewModel);
            //}

            //SessionManager.UsuarioLogado = usuario;

            return RedirectToAction("Index", "Home");
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadEvento(string usuario)
        {
            var usuarioId = _servicoDeUsuario.RecuperaUsuarioPorEmail(usuario);
            var eventosList = _servicoDeEventoUsuario.BuscarEventos(Convert.ToInt32(usuarioId.UsuarioId));
            var eventosData = eventosList.Select(m => new SelectListItem
            {
                Text = m.EventosLista.Nome,
                Value = m.EventosLista.EventoId.ToString(CultureInfo.InvariantCulture),
            });
            return Json(eventosData, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}