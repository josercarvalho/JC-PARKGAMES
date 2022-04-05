using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using JC_PARK.Web.MVC.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace JC_PARK.Web.MVC.Controllers
{
    [Authorize]
    public class DespesaController : Controller
    {
        private readonly IAppServicoDeDespesa _servicoDeDespesa;
        private readonly IAppServicoDeEventos _servicoDeEventos;

        public DespesaController(IAppServicoDeDespesa servicoDeDespesa, IAppServicoDeEventos servicoDeEventos)
        {
            _servicoDeDespesa = servicoDeDespesa;
            _servicoDeEventos = servicoDeEventos;
        }

        #region CRUD Despesa

        // GET: Despesa
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

            var despesa = _servicoDeEventos.RecuperarTodos(); //.OrderByDescending(e => e.DataCadastro);

            if (!String.IsNullOrEmpty(searchString))
            {
                despesa = despesa.Where(s => s.Nome.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Nome_desc":
                    despesa = despesa.OrderByDescending(s => s.Nome);
                    break;
                case "Data":
                    despesa = despesa.OrderBy(s => s.DataCadastro);
                    break;
                case "Data_desc":
                    despesa = despesa.OrderByDescending(s => s.DataCadastro);
                    break;
                default:
                    despesa = despesa.OrderBy(s => s.Nome);
                    break;
            }

            const int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(despesa.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Exemplo()
        {
            return View();
        }

        // GET: Despesa/Create
        public ActionResult Create(int id)
        {
            var evento = _servicoDeEventos.RecuperarPorID(id);
            var despesa = _servicoDeDespesa.BuscaPorEvento(id);
            Session["Evento"] = evento.EventoId;

            return View(evento);
        }

        // POST: Despesa/Create
        [HttpPost]
        public JsonResult Create(Despesa despesa)
        {
            try
            {
                // TODO: Add insert logic here
                var evento = (int)Session["Evento"];
                var novadespesa = new Despesa
                {
                    EventoId = evento,
                    DataCadastro = despesa.DataCadastro,
                    ValorEntrada = despesa.ValorEntrada,
                    ValorDespesa = despesa.ValorDespesa
                };

                _servicoDeDespesa.Inserir(novadespesa);

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
            return Json(despesa, JsonRequestBehavior.AllowGet);
        }

        // GET: Despesa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Despesa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public JsonResult GetDespesa(int eventoId)
        {
            var retorno = (_servicoDeDespesa.BuscaPorEvento(eventoId).ToList());
            var relacaoDespesa = GetRelacaoDespesa(retorno);

            return Json(relacaoDespesa, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult _RelacaoDespesa(int id, string nome)
        {
            ViewBag.NomeEvento = nome;
            var despesa = (_servicoDeDespesa.BuscaPorEvento(id).ToList());
            var relacaoDespesa = GetRelacaoDespesa(despesa);

            return PartialView("_Despesas", relacaoDespesa);
        }

        private static List<DespesaVM> GetRelacaoDespesa(List<Despesa> despesa)
        {
            var relacao = new List<DespesaVM>();
            foreach (var item in despesa)
            {
                var patio = (float)item.ValorEntrada * 0.2;
                var dia = (float)item.ValorEntrada - (float)patio - (float)item.ValorDespesa;
                var novo = new DespesaVM
                {
                    EventoId = item.EventoId,
                    DataCadastro = item.DataCadastro,
                    ValorEntrada = item.ValorEntrada,
                    DescontoPatio = (decimal)patio,
                    ValorDespesa = item.ValorDespesa,
                    TotalDia = (decimal)dia
                };
                relacao.Add(novo);
            };

            return (relacao);
        }
        // POST: Despesa/ExcluirDespesa/5
        [HttpPost]
        public ActionResult ExcluirDespesa(int id, FormCollection collection)
        {
            try
            {
                _servicoDeDespesa.Remover(id);
            }
            catch (Exception)
            {
                return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Status = false }, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}
