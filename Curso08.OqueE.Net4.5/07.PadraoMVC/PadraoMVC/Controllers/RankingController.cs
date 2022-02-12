using PadraoMVC.Models;
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
            //ViewBag.Id = 8;
            //ViewBag.Avatar = "👩🏾";
            //ViewBag.PlayerName = "Marlene F. Martelli";
            //ViewBag.Points = 1298;

            List<Score> modelo = new List<Score>
            {
                new Score(8, "👩🏾", "Marlene F. Martelli", 1298),
                new Score(1, "👨🏽", "Caio D. Torres", 800),
                new Score(7, "👩🏿", "Sandra D. Martins", 765),
                new Score(3, "👨🏾", "Tiago O. Vieira", 721)
            };

            return View(modelo);
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