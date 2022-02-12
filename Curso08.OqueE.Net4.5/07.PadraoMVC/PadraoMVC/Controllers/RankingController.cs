using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PadraoMVC.Controllers
{
    public class RankingController : Controller
    {
        //ViewResult - representa HTML
        public ActionResult Index()
        {
            return View();
        }

        //EmptyResult - não representa nenhum resultado
        public ActionResult Vazio()
        {
            return new EmptyResult();
        }

        //RedirectResult - redirecionamento para outra URL
        public ActionResult VaiPraHome()
        {
            return Redirect("/Home/Index");
        }

        //JsonResult - objeto na notação JSON
        public ActionResult Json()
        {
            var obj = new { id = 1234, nome = "Fulano de Tal" };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        //ContentResult - resultado de texto
        public ActionResult OlaMundo()
        {
            return Content("Olá, Mundo!");
        }

        //FileContentResult - arquivo para download
        public ActionResult Logo()
        {
            var path = Server.MapPath("~/Images/gama.png");
            var contentType = "data:image/png;base64,{0}";
            return File(path, contentType, "logo.png");
        }
    }
}