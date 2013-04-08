using System.Web.Mvc;
using System.Web.Security;
using Aplicacao;
using Dominio;

namespace ViewGuiWeb.Controllers
{
    public class LogarController : Controller
    {
        //
        // GET: /Logar/
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
                    return RedirectToAction("Index", "Painel", new { Area = "Area51" });
                }
                ViewBag.Menssage = "Usuário ou senha não confere";
            }
            //Se não for valido

            return View();
        }

    }
}
