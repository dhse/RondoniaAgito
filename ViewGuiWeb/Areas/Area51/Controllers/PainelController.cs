using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ViewGuiWeb.Areas.Area51.Controllers
{
    public class PainelController : Controller
    {
        //
        // GET: /Area51/Painel/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
