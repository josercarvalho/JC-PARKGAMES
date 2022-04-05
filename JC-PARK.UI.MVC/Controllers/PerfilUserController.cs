using System;
using System.Web.Mvc;
using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using PagedList;

namespace JC_PARK.Web.MVC.Controllers
{
    public class PerfilUserController : Controller
    {
        private readonly IAppServicoDePerfilUsuario _servicoDePerfilUsuario;


        public PerfilUserController(IAppServicoDePerfilUsuario servicoDePerfilUsuario)
        {
            _servicoDePerfilUsuario = servicoDePerfilUsuario;
        }

        // GET: PerfilUser
        public ActionResult Index(int? page)
        {
            var perfilUsuario = _servicoDePerfilUsuario.RecuperarTodos();
            const int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(perfilUsuario.ToPagedList(pageNumber, pageSize));
        }

        // GET: PerfilUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerfilUser/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PerfilUsuario perfilUsuario)
        {
            if (!ModelState.IsValid) return View(perfilUsuario);
            _servicoDePerfilUsuario.Inserir(perfilUsuario);
            return RedirectToAction("Index");
        }

        // GET: PerfilUser/Edit/5
        public ActionResult Edit(int id)
        {
            var perfiluser = _servicoDePerfilUsuario.RecuperarPorID(id);
            return View(perfiluser);
        }

        // POST: PerfilUser/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PerfilUsuario perfilUsuario)
        {
            if (!ModelState.IsValid) return View(perfilUsuario);
            _servicoDePerfilUsuario.Alterar(perfilUsuario);
            return RedirectToAction("Index");
        }

        // POST: Empresa/DeletePerfilUser/5
        [HttpPost]
        public JsonResult ExcluiPerfilUser(int id)
        {
            var mensagemErro = "Excluído com sucesso...";
            try
            {
                var empresa = _servicoDePerfilUsuario.RecuperarPorID(id);
                _servicoDePerfilUsuario.Remover(empresa);
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }
    }
}
