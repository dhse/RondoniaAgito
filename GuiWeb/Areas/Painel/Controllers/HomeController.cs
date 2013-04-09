using System.Web.Mvc;
using System.Web.Security;
using Aplicacao;
using Dominio;

namespace GuiWeb.Areas.Painel.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Painel/Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin, string returnUrl = "")
        {
            //Validando
            if (ModelState.IsValid)
            {
                //Se for valido
                var adminaplicacao = new AdminAplicacao();
                if (adminaplicacao.Logar(admin))
                {
                    //Verificando se o usuario tem permissão pra acessa essa pagina
                    FormsAuthentication.SetAuthCookie(admin.AdminLogin, false);
                    /*
                     * Se o Usuario tentar acessa uma URL Valida e não estiver logado este If ira pega essa URL
                     * Solicita o login, apos logar redireciona o usuario pra URL que o mesmo tentou acessar
                     */
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    //Redirecionando o usuario pra tela inicial do sistema
                    return RedirectToAction("Logado", "Home", new { Area = "Painel" });
                }
                ViewBag.Menssage = "Usuário ou senha não confere";
            }
            //Se não for valido

            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        [Authorize]
        public  ActionResult Logado()
        {
            return View();
        }

        [Authorize]
        public ActionResult Admin()
        {
            return View();
        }

        [Authorize]
        public ActionResult Eventos()
        {
            return View();
        }

        [Authorize]
        public ActionResult AsMinasPira()
        {
            return View();
        }

        [Authorize]
        public ActionResult Contato()
        {
            return View();
        }

        [Authorize]
        public ActionResult QuemSomos()
        {
            return View();
        }
    }
}
