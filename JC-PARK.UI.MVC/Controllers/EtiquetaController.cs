using System;
using JC_PARK.Aplication.Interface;
using System.Web.Mvc;
using JC_PARK.Domain.Entities;
using PagedList;

namespace JC_PARK.Web.MVC.Controllers
{
    public class EtiquetaController : Controller
    {
        private readonly IAppServicoDaEtiqueta _servicoDaEtiqueta;
        private readonly IAppServicoDaEmpresa _servicoDaEmpresa;

        public EtiquetaController(IAppServicoDaEtiqueta servicoDaEtiqueta, IAppServicoDaEmpresa servicoDaEmpresa)
        {
            _servicoDaEtiqueta = servicoDaEtiqueta;
            _servicoDaEmpresa = servicoDaEmpresa;
        }

        // GET: Etiqueta
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

            var etiqueta = _servicoDaEtiqueta.RecuperarTodos();

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    etiqueta = etiqueta.Where(s => s.Nome.ToUpper().Contains(searchString.ToUpper()));
            //}
            //switch (sortOrder)
            //{
            //    case "Nome_desc":
            //        etiqueta = etiqueta.OrderByDescending(s => s.Nome);
            //        break;
            //    case "Data":
            //        etiqueta = etiqueta.OrderBy(s => s.DataCadastro);
            //        break;
            //    case "Data_desc":
            //        etiqueta = etiqueta.OrderByDescending(s => s.DataCadastro);
            //        break;
            //    default:
            //        etiqueta = etiqueta.OrderBy(s => s.Nome);
            //        break;
            //}

            const int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(etiqueta.ToPagedList(pageNumber, pageSize));
        }

        // GET: Etiqueta/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(_servicoDaEmpresa.RecuperarTodos(), "EmpresaId", "Nome");
            return View();
        }

        // POST: Etiqueta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                _servicoDaEtiqueta.Inserir(etiqueta);
                return RedirectToAction("Index");
            }

            return View(etiqueta);
        }

        // GET: Etiqueta/Edit/5
        public ActionResult Edit(int id)
        {
            var etiqueta = _servicoDaEtiqueta.RecuperarPorID(id);
            //ViewBag.EmpresaId = new SelectList(_servicoDaEmpresa.RecuperarTodos(), "EmpresaId", "Nome", etiqueta.EventoId);
            return View(etiqueta);
        }

        // POST: Etiqueta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                _servicoDaEtiqueta.Alterar(etiqueta);
                return RedirectToAction("Index");
            }

            return View(etiqueta);
        }

        // POST: Empresa/DeletePerfilUser/5
        [HttpPost]
        public JsonResult ExcluiEtiquera(int id)
        {
            var mensagemErro = "Excluído com sucesso...";
            try
            {
                var empresa = _servicoDaEtiqueta.RecuperarPorID(id);
                _servicoDaEtiqueta.Remover(empresa);
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }
    }
}
