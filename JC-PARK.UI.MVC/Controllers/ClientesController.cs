using System.Web.Mvc;
using JC_PARK.Aplication.Interface;
using System;
using JC_PARK.Domain.Entities;
using System.IO;
using System.Linq;
using PagedList;

namespace JC_PARK.Web.MVC.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly IAppServicoDeCliente _servicoDeCliente;
        private readonly IAppServicoDeValores _servicoDeValores;
        
        public ClientesController(IAppServicoDeCliente servicoDeCliente, IAppServicoDeValores servicoDeValores)
        {
            _servicoDeValores = servicoDeValores;
            _servicoDeCliente = servicoDeCliente;
        }

        #region CRUD do Cliente (criança)

        // GET: Clientes
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NomeParam = String.IsNullOrEmpty(sortOrder) ? "Nome_desc" : "";
            ViewBag.DateParm = sortOrder == "Date" ? "Date_desc" : "Date";
            Session["val"] = "";
            
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var cliente = _servicoDeCliente.RecuperarTodos();

            if (!String.IsNullOrEmpty(searchString))
            {
                cliente = cliente.Where(s => s.NomeCrianca.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Nome_desc":
                    cliente = cliente.OrderByDescending(s => s.NomeCrianca);
                    break;
                case "Data":
                    cliente = cliente.OrderBy(s => s.DataCadastro);
                    break;
                case "Data_desc":
                    cliente = cliente.OrderByDescending(s => s.DataCadastro);
                    break;
                default:
                    cliente = cliente.OrderBy(s => s.NomeCrianca);
                    break;
            }

            const int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(cliente.ToPagedList(pageNumber, pageSize));
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {

            string sss = Session["val"].ToString();

            if (sss != string.Empty)
            {
                ViewBag.pic = "../../WebImages/" + sss ;
                ViewBag.nomefoto = "";
            }
            else
            {
                ViewBag.pic = "../../WebImages/Anonymous.png";
                ViewBag.nomefoto = "Sem foto";
            }

            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    if (Convert.ToString(Session["val"]) != string.Empty)
                    {
                        cliente.Foto = Convert.ToString(Session["val"]);
                        _servicoDeCliente.Inserir(cliente);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("","Está faltando a foto do cliente!");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _servicoDeCliente.RecuperarPorID(id);

            if (cliente.Foto != string.Empty)
            {
                ViewBag.pic = "../../WebImages/" + cliente.Foto;
            } 
            else
            {
                ViewBag.pic = "../../WebImages/Anonymous.png";
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _servicoDeCliente.Alterar(cliente);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View(cliente);
        }

        // POST: Cargos/Delete/5
        [HttpPost]
        public JsonResult DeleteCliente(int id)
        {
            var mensagemErro = "Excluído com sucesso...";
            try
            {
                var cliente = _servicoDeCliente.RecuperarPorID(id);
                _servicoDeCliente.Remover(cliente);
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Foto do Cliente

        [HttpGet]
        public ActionResult Changephoto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(string image)
        {
            image = image.Substring("data:image/png;base64,".Length);
            var buffer = Convert.FromBase64String(image);
            DateTime nm = DateTime.Now;
            string date = nm.ToString("yyyymmddMMss");
            var path = Server.MapPath("~/WebImages/" + date + "cliente.jpg");
            System.IO.File.WriteAllBytes(path, buffer);
            return Json(new { success = true });
        }

        [HttpGet]
        public ActionResult Foto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Foto(string Imagename)
        {
            string sss = Session["val"].ToString();

            ViewBag.pic = "../../WebImages/" + sss ;

            return View();
        }

        public JsonResult Rebind()
        {
            string path = "../../WebImages/" + Session["val"].ToString();

            return Json(path, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Capture()
        {
            var stream = Request.InputStream;
            string dump;

            using (var reader = new StreamReader(stream))
            {
                dump = reader.ReadToEnd();

                DateTime nm = DateTime.Now;

                string date = nm.ToString("yyyymmddMMss");

                var path = Server.MapPath("~/WebImages/" + date + "cliente.jpg");

                System.IO.File.WriteAllBytes(path, String_To_Bytes2(dump));

                ViewData["path"] = date + "cliente.jpg";

                Session["val"] = date + "cliente.jpg";
            }

            return View("Foto");
        }

        private byte[] String_To_Bytes2(string strInput)
        {
            int numBytes = (strInput.Length) / 2;

            byte[] bytes = new byte[numBytes];

            for (int x = 0; x < numBytes; ++x)
            {
                bytes[x] = Convert.ToByte(strInput.Substring(x * 2, 2), 16);
            }

            return bytes;
        }

        #endregion


        //public ActionResult Entrada()
        //{
        //    //ViewBag.Evento = SessionManager.UsuarioLogado.Evento.Nome;
        //    ViewBag.DataCadastro = DateTime.Now;
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Entrada(Cliente cliente)
        //{
        //    string erro = string.Empty;
        //    //ViewBag.empresa = SessionManager.UsuarioLogado.Evento.Nome;

        //    //cliente.EmpresaId = SessionManager.UsuarioLogado.EmpresaId;
        //    cliente.DataCadastro = DateTime.Now;
        //    cliente.HoraEntrada = DateTime.Now;



        //    if (cliente.EtiquetaId == 0)
        //    {
        //        ModelState.AddModelError("EtiquetaId", "Campo da Pulseira obrigatório!");
        //        erro = "1";
        //    }

        //    if (erro != "")
        //    {

        //        ModelState.AddModelError("", "Dados inconsistentes. Verifique!");
        //        return View(cliente);
        //    }

        //    var etiquetaSalva = _servicoDeCliente.BuscaPorEtiqueta(cliente.EtiquetaId);
        //    if (etiquetaSalva != null)
        //    {
        //        ModelState.AddModelError("", "DADOS JÁ FORAM SALVOS. ENTRE COM UM NOVO CLIENTE!");
        //        return View(cliente);
        //    }

        //    cliente.Ativo = true;
        //    _servicoDeCliente.Inserir(cliente);
        //    return View(cliente);
        //}

        //public PartialViewResult _Saida(int etiqueta)
        //{
        //    //var empresaId = SessionManager.UsuarioLogado.EmpresaId;
        //    var cliente = _servicoDeCliente.BuscaPorEtiqueta(etiqueta);
        //    if (cliente != null && cliente.Ativo)
        //    {
        //        var valorHora = _servicoDeValores.BuscarPorEvento(cliente.EventoId);

        //        cliente.HoraSaida = DateTime.Now;
        //        DateTime horaChegada = DateTime.Parse(cliente.HoraEntrada.ToString(CultureInfo.CurrentCulture));
        //        DateTime horaSaida = DateTime.Parse(cliente.HoraSaida.ToString(CultureInfo.CurrentCulture));
        //        TimeSpan tempoPercorrido;
        //        tempoPercorrido = horaSaida.Subtract(horaChegada);
        //        var valorSaida = (decimal)tempoPercorrido.TotalMinutes;
        //        cliente.ValorTotal = (valorHora.ValorEPorMinuto * valorSaida);
        //        cliente.Valor = valorHora.ValorNormal;
        //        cliente.ValorExcedente = valorHora.ValorEPorMinuto;
        //        cliente.Ativo = false;
        //    }
        //    //else
        //    //{
        //    //    ModelState.AddModelError("Pulseira Inválida para esta empresa ou já utilizada!");
        //    //    return View(etiqueta);
        //    //}

        //    _servicoDeCliente.Alterar(cliente);

        //    System.Threading.Thread.Sleep(3000);
        //    return PartialView(cliente);
        //}
    }
}
