using System;
using System.Web.Mvc;
using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using PagedList;

namespace JC_PARK.Web.MVC.Controllers
{
    public class TipoValorController : Controller
    {
        private readonly IAppServicoDeTipoValor _servicoDeTipoValor;
        private readonly IAppServicoDaEmpresa _servicoDaEmpresa;

        public TipoValorController(IAppServicoDeTipoValor servicoDeTipoValor, IAppServicoDaEmpresa servicoDaEmpresa)
        {
            _servicoDeTipoValor = servicoDeTipoValor;
            _servicoDaEmpresa = servicoDaEmpresa;
        }

        // GET: TipoValor
        public ActionResult Index( int? page)
        {
            var tipovalor = _servicoDeTipoValor.RecuperarTodos();
            const int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(tipovalor.ToPagedList(pageNumber, pageSize)); 
        }
        
        // GET: TipoValor/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(_servicoDaEmpresa.RecuperarTodos(), "EmpresaId", "Nome");
            return View();
        }

        // POST: TipoValor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoValor tipoValor)
        {
            if (!ModelState.IsValid) return View(tipoValor);
            _servicoDeTipoValor.Inserir(tipoValor);
            return RedirectToAction("Index");
        }

        // GET: TipoValor/Edit/5
        public ActionResult Edit(int id)
        {
            var tipoValor = _servicoDeTipoValor.RecuperarPorID(id);
            //ViewBag.EmpresaId = new SelectList(_servicoDaEmpresa.RecuperarTodos(), "EmpresaId", "Nome", tipoValor.EventoId);
            return View(tipoValor);
        }

        // POST: TipoValor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoValor tipoValor)
        {
            if (!ModelState.IsValid) return View(tipoValor);
            _servicoDeTipoValor.Alterar(tipoValor);
            return RedirectToAction("Index");
        }

        // POST: Empresa/DeleteEmpresa/5
        [HttpPost]
        public JsonResult DeleteTipoValor(int id)
        {
            var mensagemErro = "Excluído com sucesso...";
            try
            {
                var empresa = _servicoDeTipoValor.RecuperarPorID(id);
                _servicoDeTipoValor.Remover(empresa);
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }
    }
}
