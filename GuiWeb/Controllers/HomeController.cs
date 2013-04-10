using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacao;
using Dominio;

namespace GuiWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Eventos()
        {
            return View();
        }

        public ActionResult AsMinasPira()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contato(Contato contato)
        {
            if (ModelState.IsValid)
            {
                var contatoAplicacao = new ContatoAplicacao();
                contatoAplicacao.Salvar(contato);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult QuemSomos()
        {
            var quemSomosAplicacao = new QuemSomosAplicacao();
            var lista = quemSomosAplicacao.ListarTodos();
            foreach (var quemSomos in lista)
            {
                ViewBag.quemSomos = quemSomos.QuemSomosDescricao;
            }
            return View();
        }

    }
}
