using System;
using System.Web.Mvc;
using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using PagedList;

namespace JC_PARK.Web.MVC.Controllers
{
    public class ValorController : Controller
    {
        private readonly IAppServicoDeValores _servicoDeValores;
        private readonly IAppServicoDeEventos _servicoDeEventos;
        private readonly IAppServicoDeTipoValor _servicoDeTipoValor;

        public ValorController(IAppServicoDeValores servicoDeValores, IAppServicoDeEventos  servicoDeEventos, IAppServicoDeTipoValor servicoDeTipoValor)
        {
            _servicoDeValores = servicoDeValores;
            _servicoDeEventos = servicoDeEventos;
            _servicoDeTipoValor = servicoDeTipoValor;
        }

        // GET: Valor
        public ActionResult Index(int? page)
        {
            var tipovalor = _servicoDeValores.BuscarTodos();

            const int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(tipovalor.ToPagedList(pageNumber, pageSize));
        }

        // GET: Valor/Create
        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(_servicoDeEventos.RecuperarTodos(), "EventoId", "Nome");
            ViewBag.TipoValorId = new SelectList(_servicoDeTipoValor.RecuperarTodos(), "TipoValorId", "Nome");
            return View();
        }

        // POST: Valor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Valores valor)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EmpresaId = new SelectList(_servicoDeEventos.RecuperarTodos(), "EmpresaId", "Nome");
                ViewBag.TipoValorId = new SelectList(_servicoDeTipoValor.RecuperarTodos(), "TipoValorId", "Nome");
                return View(valor);                
            }
            _servicoDeValores.Inserir(valor);
            return RedirectToAction("Index");
        }

        // GET: Valor/Edit/5
        public ActionResult Edit(int id)
        {
            var valor = _servicoDeValores.RecuperarPorID(id);
            ViewBag.EventoId = new SelectList(_servicoDeEventos.RecuperarTodos(), "EventoId", "Nome", valor.EventoId);
            ViewBag.TipoValorId = new SelectList(_servicoDeTipoValor.RecuperarTodos(), "TipoValorId", "Nome", valor.TipoValorId);

            return View(valor);
        }

        // POST: Valor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Valores valor)
        {
            if (!ModelState.IsValid) return View(valor);
            _servicoDeValores.Alterar(valor);
            return RedirectToAction("Index");
        }
        
        // POST: Empresa/DeleteEmpresa/5
        [HttpPost]
        public JsonResult DeleteValor(int id)
        {
            var mensagemErro = "Excluído com sucesso...";
            try
            {
                var empresa = _servicoDeValores.RecuperarPorID(id);
                _servicoDeValores.Remover(empresa);
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }
    }
}
