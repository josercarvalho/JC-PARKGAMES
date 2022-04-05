using System;
using System.Linq;
using System.Web.Mvc;
using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using PagedList;

namespace JC_PARK.Web.MVC.Controllers
{
    [Authorize]
    public class EmpresaController : Controller
    {
        private readonly IAppServicoDaEmpresa _servicoDaEmpresa;

        public EmpresaController(IAppServicoDaEmpresa servicoDaEmpresa)
        {
            _servicoDaEmpresa = servicoDaEmpresa;
        }

        // GET: Empresa
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

            var empresa = _servicoDaEmpresa.RecuperarTodos();

            if (!String.IsNullOrEmpty(searchString))
            {
                empresa = empresa.Where(s => s.Nome.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Nome_desc":
                    empresa = empresa.OrderByDescending(s => s.Nome);
                    break;
                case "Data":
                    empresa = empresa.OrderBy(s => s.DataCadastro);
                    break;
                case "Data_desc":
                    empresa = empresa.OrderByDescending(s => s.DataCadastro);
                    break;
                default:
                    empresa = empresa.OrderBy(s => s.Nome);
                    break;
            }

            const int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(empresa.ToPagedList(pageNumber, pageSize));
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _servicoDaEmpresa.Inserir(empresa);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(empresa);
        }

        //public ActionResult Novo()
        //{
        //    return View("AddEditCliente", new Empresa());
        //}

        // GET: Empresa/Edit/5
        public ActionResult Edit(int id)
        {
            var empresa = _servicoDaEmpresa.RecuperarPorID(id);
            return View(empresa);
        }

        // POST: Empresa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _servicoDaEmpresa.Alterar(empresa);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View(empresa);
        }

        // POST: Empresa/DeleteEmpresa/5
        [HttpPost]
        public JsonResult DeleteEmpresa(int id)
        {
            var mensagemErro = "Excluído com sucesso...";
            try
            {
                var empresa = _servicoDaEmpresa.RecuperarPorID(id);
                _servicoDaEmpresa.Remover(empresa);
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }
    }
}
