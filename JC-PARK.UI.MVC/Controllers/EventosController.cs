using System;
using System.Linq;
using System.Web.Mvc;
using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using PagedList;
using System.Net;
using System.Data.Entity.Validation;

namespace JC_PARK.Web.MVC.Controllers
{
    [Authorize]
    public class EventosController : Controller
    {
        private readonly IAppServicoDeEventos _servicoDeEventos;
        private readonly IAppServicoDeUsuario _servicoDeUsuario;
        private readonly IAppServicoDeEventoUsuario _servicoDeEventoUsuario;

        public EventosController(IAppServicoDeEventos servicoDeEventos, IAppServicoDeUsuario servicoDeUsuario, IAppServicoDeEventoUsuario servicoDeEventoUsuario)
        {
            _servicoDeEventos = servicoDeEventos;
            _servicoDeUsuario = servicoDeUsuario;
            _servicoDeEventoUsuario = servicoDeEventoUsuario;
        }

        #region CRUD do Evento

        // GET: Eventos
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

            var evento = _servicoDeEventos.RecuperarTodos();

            if (!String.IsNullOrEmpty(searchString))
            {
                evento = evento.Where(s => s.Nome.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Nome_desc":
                    evento = evento.OrderByDescending(s => s.Nome);
                    break;
                case "Data":
                    evento = evento.OrderBy(s => s.DataCadastro);
                    break;
                case "Data_desc":
                    evento = evento.OrderByDescending(s => s.DataCadastro);
                    break;
                default:
                    evento = evento.OrderBy(s => s.Nome);
                    break;
            }

            const int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(evento.ToPagedList(pageNumber, pageSize));
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            //var evento = new Evento();
            //evento.DataInicial = new DateTime();
            //evento.DataFinal = new DateTime();

            //evento.UsuarioLista = new SelectList(_servicoDeUsuario.RecuperarTodos(), "UsuarioID", "Nome").ToList();

            ViewBag.UsuarioId = new SelectList(_servicoDeUsuario.RecuperarTodos(), "UsuarioID", "Nome");
            return View("Create");
        }

        // POST: Eventos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Evento evento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _servicoDeEventos.Inserir(evento);
                    ViewBag.EventoId = evento.EventoId;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                throw;
            }

            ViewBag.UsuarioId = new SelectList(_servicoDeUsuario.RecuperarTodos().ToList(), "UsuarioID", "Nome");
            return View(evento);
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _servicoDeEventos.RecuperarPorID(id);
            ViewBag.UsuarioId = new SelectList(_servicoDeUsuario.RecuperarTodos(), "UsuarioID", "Nome");

            return View(model);
        }

        // POST: Eventos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Evento evento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _servicoDeEventos.Alterar(evento);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost]
        public JsonResult DeleteEvento(int id)
        {
            var mensagemErro = "Excluído com sucesso...";
            try
            {
                var empresa = _servicoDeEventos.RecuperarPorID(id);
                _servicoDeEventos.Remover(empresa);
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }
        #endregion

        #region Usuarios do Evento

        public PartialViewResult _RelacaoUsuario(int id, string nome)
        {
            var indicados = _servicoDeEventoUsuario.RecuperarPorID(id);
            ViewBag.NomeEvento = nome;
            System.Threading.Thread.Sleep(3000);
            return PartialView(indicados);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult BuscaFuncionario(int usuarioId)
        {
            var usuarioBusca = (_servicoDeUsuario.RecuperarPorID(usuarioId));

            return Json(usuarioBusca.Nome, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetEvento(int eventoId)
        {
            var retorno = (_servicoDeEventoUsuario.BuscarUsuarios(eventoId));

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetNames(string term)
        {
            // A list of names to mimic results from a database
            var nameList = _servicoDeUsuario.RecuperarTodos().Select(u => u.Nome).ToList();
            var results = nameList.Where(n => n.StartsWith(term, StringComparison.OrdinalIgnoreCase));

            return new JsonResult
            {
                Data = results.ToArray(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public JsonResult SalvarUsuarioEvento(EventoUsuario eventoUsuario)
        {
            try
            {
                eventoUsuario.DataCadastro = DateTime.Now;
                eventoUsuario.Ativo = true;
                _servicoDeEventoUsuario.Inserir(eventoUsuario);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var error in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0} \" no estado \"{1} \" tem os seguintes erros de validação:",
                    error.Entry.Entity.GetType().Name, error.Entry.State);
                    foreach (var ve in error.ValidationErrors)
                    {
                        Console.WriteLine("-Propriedade: \"{0}\", Erro: \"{1}\"",
                                                 ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return Json(eventoUsuario, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ExcluirUsuario(int id)
        {
            var mensagemErro = "Excluído com sucesso...";
            try
            {
                var empresa = _servicoDeEventos.RecuperarPorID(id);
                _servicoDeEventos.Remover(empresa);
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult ExcluirUsuarioEvento(int id, int nomeEvento)
        {
            if (_servicoDeEventoUsuario.RemoverUsuario(id, nomeEvento))
            {
                return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Status = false }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
