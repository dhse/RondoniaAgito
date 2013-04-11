using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacao;
using Dominio;

namespace GuiWeb.Areas.Painel.Controllers
{
    [Authorize]
    public class AdministradorController : Controller
    {
        //
        // GET: /Painel/Administrador/

        public ActionResult Index()
        {
            var adminAplicacao = new AdministradorAplicacao();
            return View(adminAplicacao.ListarTodos());
        }

        public ActionResult Detalhes(int id)
        {
            var adminAplicacao = new AdministradorAplicacao();
            var admin = adminAplicacao.ListarPorId(id);
            if (admin == null)
                return HttpNotFound();
            return View(admin);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Administrador admin)
        {
            if (ModelState.IsValid)
            {
                var adminAplicacao = new AdministradorAplicacao();
                adminAplicacao.Salvar(admin);
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        public ActionResult Editar(int id)
        {
            var adminAplicacao = new AdministradorAplicacao();
            var admin = adminAplicacao.ListarPorId(id);
            if (admin == null)
                return HttpNotFound();

            return View(admin);
        }

        [HttpPost]
        public ActionResult Editar(Administrador admin)
        {
            if (ModelState.IsValid)
            {
                var adminAplicacao = new AdministradorAplicacao();
                adminAplicacao.Salvar(admin);
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        public ActionResult Excluir(int id)
        {
            var adminAplicacao = new AdministradorAplicacao();
            var admin = adminAplicacao.ListarPorId(id);
            if (admin == null)
                return HttpNotFound();

            return View(admin);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var adminAplicacao = new AdministradorAplicacao();
            adminAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
