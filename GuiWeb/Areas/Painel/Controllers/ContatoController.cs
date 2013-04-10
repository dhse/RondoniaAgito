using System.Web.Mvc;
using Aplicacao;
using Dominio;

namespace GuiWeb.Areas.Painel.Controllers
{
    public class ContatoController : Controller
    {
        //
        // GET: /Painel/Contato/
        public ActionResult Index()
        {
            var contatoAplicacao = new ContatoAplicacao();
            return View(contatoAplicacao.ListarTodos());
        }

        public ActionResult Detalhes(int id)
        {
            var contatoAplicacao = new ContatoAplicacao();
            var contato = contatoAplicacao.ListarPorId(id);
            if (contato == null)
                return HttpNotFound();
            return View(contato);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                var contatoAplicacao = new ContatoAplicacao();
                contatoAplicacao.Salvar(contato);
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        public ActionResult Editar(int id)
        {
            var contatoAplicacao = new ContatoAplicacao();
            var contato = contatoAplicacao.ListarPorId(id);
            if (contatoAplicacao == null)
                return HttpNotFound();

            return View(contato);
        }

        [HttpPost]
        public ActionResult Editar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                var contatoAplicacao = new ContatoAplicacao();
                contatoAplicacao.Salvar(contato);
                return RedirectToAction("Index");
            }

            return View(contato);
        }

        public ActionResult Excluir(int id)
        {
            var contatoAplicacao = new ContatoAplicacao();
            var contato = contatoAplicacao.ListarPorId(id);
            if (contato == null)
                return HttpNotFound();

            return View(contato);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var contatoAplicacao = new ContatoAplicacao();
            contatoAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
