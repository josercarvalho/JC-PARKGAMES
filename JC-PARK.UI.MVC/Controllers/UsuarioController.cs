using System;
using System.Linq;
using System.Web.Mvc;
using JC_PARK.Aplication.Interface;
using JC_PARK.Web.MVC.Util;
using JC_PARK.Domain.Entities;
using PagedList;

namespace JC_PARK.Web.MVC.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IAppServicoDeUsuario _servicoDeUsuario;
        private readonly IAppServicoDePonto _servicoDePonto;
        private readonly IAppServicoDeEventos _servicoDeEventos;
        private readonly IAppServicoDeEventoUsuario _servicoDeEventoUsuario;
        private readonly IAppServicoDePerfilUsuario _servicoDePerfilUsuario;

        public UsuarioController(IAppServicoDeUsuario servicoDeUsuario, IAppServicoDeEventos servicoDeEventos, IAppServicoDePerfilUsuario servicoDePerfilUsuario, IAppServicoDeEventoUsuario servicoDeEventoUsuario, IAppServicoDePonto servicoDePonto)
        {
            _servicoDeUsuario = servicoDeUsuario;
            _servicoDeEventos = servicoDeEventos;
            _servicoDePonto = servicoDePonto;
            _servicoDeEventoUsuario = servicoDeEventoUsuario;
            _servicoDePerfilUsuario = servicoDePerfilUsuario;
        }

        #region CRUD do usuário 

        // GET: Usuario
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NomeParam = String.IsNullOrEmpty(sortOrder) ? "Nome_desc" : "";
            ViewBag.DateParm = sortOrder == "Date" ? "Date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var usuario = _servicoDeUsuario.RecuperarTodos();

            if (!String.IsNullOrEmpty(searchString))
            {
                usuario = usuario.Where(s => s.Nome.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Nome_desc":
                    usuario = usuario.OrderByDescending(s => s.Nome);
                    break;
                case "Data":
                    usuario = usuario.OrderBy(s => s.DataCadastro);
                    break;
                case "Data_desc":
                    usuario = usuario.OrderByDescending(s => s.DataCadastro);
                    break;
                default:
                    usuario = usuario.OrderBy(s => s.Nome);
                    break;
            }

            const int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(usuario.ToPagedList(pageNumber, pageSize));
        }

        //public ActionResult novo()
        //{
        //    return View();
        //}

        //GET: Usuario/Create
        public ActionResult Create()
        {
            //ViewBag.EventoId = new SelectList(_servicoDeEventos.RecuperarTodos(), "EventoId", "Nome");
            ViewBag.PerfilUsuarioId = new SelectList(_servicoDePerfilUsuario.RecuperarTodos(), "PerfilUsuarioId", "NomPerfil");
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _servicoDeUsuario.Inserir(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            var usuario = _servicoDeUsuario.RecuperarPorID(id);
            //ViewBag.EventoId = new SelectList(_servicoDeEventos.RecuperarTodos(), "EventoId", "Nome");
            ViewBag.PerfilUsuarioId = new SelectList(_servicoDePerfilUsuario.RecuperarTodos(), "PerfilUsuarioId", "NomPerfil", usuario.PerfilUsuarioId);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario usuario)
        {

            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        db.Alunos.Add(aluno);
            //        db.SaveChanges();
            //        return RedirectToAction("Index");
            //    }
            //}
            //catch (RetryLimitExceededException  /* dex */)
            //{
            //    ModelState.AddModelError("", "Não foi possível salvar as alterações. Tente de novo, e se o problema persistir consulte o administrador do sistema.");
            //}

            //return View(aluno);

            if (ModelState.IsValid)
            {
                _servicoDeUsuario.Alterar(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // POST: Usuario/DeleteUsuario/5
        [HttpPost]
        public JsonResult DeleteUsuario(int id)
        {
            string mensagemErro = "Excluído com sucesso...";
            try
            {
                var usuario = _servicoDeUsuario.RecuperarPorID(id);
                _servicoDeUsuario.Remover(usuario);
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }

        #endregion

        #region Evento x Usuário

        public ActionResult _ListarEventos(int id, string nome)
        {
            if (nome == "admin") return View();

            var evento = _servicoDeEventoUsuario.RecuperarPorUsuario(id);

            var usuario = _servicoDeEventoUsuario.BuscarEventos(id);
            ViewBag.NomeFunc = nome;
            System.Threading.Thread.Sleep(2000);
            return PartialView(usuario);
        }

        #endregion

        #region Manutenção do Ponto

        [HttpPost]
        public JsonResult Ponto()
        {
            var mensagemErro = "Ponto batido com sucesso...";
            var usuario = SessionManager.UsuarioLogado.UsuarioId;
            var diaAtual = DateTime.Now.Date;

            try
            {
                // *** Verifica se permissão de usuário no evento ***
                var evento = _servicoDeEventoUsuario.RecuperarPorUsuario(usuario);

                if (evento == null)
                {
                    mensagemErro = "Usuário não CADASTRADO para Evento";
                }
                else
                {
                    // *** Veriifca ponto a ser batido se entrada ou saída ***
                    var ponto = _servicoDePonto.BuscarPonto(usuario, evento.EventoId, diaAtual);
                    if (ponto == null)
                    {
                        _servicoDePonto.BaterPonto(usuario, evento.EventoId);
                    }
                    else
                    {
                        var horaAtual = DateTime.Now.TimeOfDay;
                        if (ponto.HoraEntrada != null && horaAtual < evento.HoraSaida.TimeOfDay)
                        {
                            mensagemErro = "Horário inválido !!!";
                        }
                        else
                        {
                            _servicoDePonto.BaterPonto(usuario, ponto.EventoId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }

        public ActionResult _ListarPonto(int id, string tipo)
        {
            return PartialView("_ListarPonto");
        }

        #endregion
    }
}
