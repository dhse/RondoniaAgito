using System.Web.Mvc;
using Aplicacao;
using Dominio;

namespace GuiWeb.Areas.Painel.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Painel/Admin/

        public ActionResult Index()
        {
            var adminAplicacao = new AdminAplicacao();
            return View(adminAplicacao.ListarTodos());
        }

        public ActionResult Detalhes(int id)
        {
            var adminAplicacao = new AdminAplicacao();
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
        public ActionResult Cadastrar(Admin admin)
        {
            if (ModelState.IsValid)
            {
                var adminAplicacao = new AdminAplicacao();
                adminAplicacao.Salvar(admin);
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        public ActionResult Editar(int id)
        {
            var adminAplicacao = new AdminAplicacao();
            var admin = adminAplicacao.ListarPorId(id);
            if (admin == null)
                return HttpNotFound();

            return View(admin);
        }

        [HttpPost]
        public ActionResult Editar(Admin admin)
        {
            if (ModelState.IsValid)
            {
                var adminAplicacao = new AdminAplicacao();
                adminAplicacao.Salvar(admin);
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        public ActionResult Excluir(int id)
        {
            var adminAplicacao = new AdminAplicacao();
            var admin = adminAplicacao.ListarPorId(id);
            if (admin == null)
                return HttpNotFound();

            return View(admin);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var adminAplicacao = new AdminAplicacao();
            adminAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
