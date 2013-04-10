using System.Web.Mvc;
using Aplicacao;
using Dominio;


namespace GuiWeb.Areas.Painel.Controllers
{
    public class QuemSomosController : Controller
    {
        //
        // GET: /Painel/QuemSomos/
        public ActionResult Index()
        {
            var quemSomosAplicacao = new QuemSomosAplicacao();
            return View(quemSomosAplicacao.ListarTodos());
        }

        public ActionResult Detalhes(int id)
        {
            var quemSomosAplicacao = new QuemSomosAplicacao();
            var quemSomos = quemSomosAplicacao.ListarPorId(id);
            if (quemSomos == null)
                return HttpNotFound();
            return View(quemSomos);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(QuemSomos quemSomos)
        {
            if (ModelState.IsValid)
            {
                var quemSomosAplicacao = new QuemSomosAplicacao();
                quemSomosAplicacao.Salvar(quemSomos);
                return RedirectToAction("Index");
            }
            return View(quemSomos);
        }

        public ActionResult Editar(int id)
        {
            var quemSomosAplicacao = new QuemSomosAplicacao();
            var quemSomos = quemSomosAplicacao.ListarPorId(id);
            if (quemSomosAplicacao == null)
                return HttpNotFound();

            return View(quemSomos);
        }

        [HttpPost]
        public ActionResult Editar(QuemSomos quemSomos)
        {
            if (ModelState.IsValid)
            {
                var quemSomosAplicacao = new QuemSomosAplicacao();
                quemSomosAplicacao.Salvar(quemSomos);
                return RedirectToAction("Index");
            }

            return View(quemSomos);
        }

        public ActionResult Excluir(int id)
        {
            var quemSomosAplicacao = new QuemSomosAplicacao();
            var quemSomos = quemSomosAplicacao.ListarPorId(id);
            if (quemSomos == null)
                return HttpNotFound();

            return View(quemSomos);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var quemSomosAplicacao = new QuemSomosAplicacao();
            quemSomosAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }


    }
}
