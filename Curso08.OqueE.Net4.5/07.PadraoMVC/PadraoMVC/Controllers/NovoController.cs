using System.Web.Mvc;

namespace PadraoMVC.Controllers
{
    public class NovoController : Controller
    {
        //ViewResult - Representa HTML e marcação.
        public ActionResult Index()
        {
            return View();
        }

        //EmptyResult - não representa nenhum resultado.
        public ActionResult Vazio()
        {
            return new EmptyResult();
        }

        //RedirectResult - representa um redirecionamento para uma nova URL.
        public ActionResult VaiPraHome()
        {
            return Redirect("/Home/Index");
        }

        //JsonResult - representa um resultado de Notação de Objeto JavaScript que pode ser usado em um aplicativo AJAX.
        public ActionResult Json()
        {
            return Json(new { isbn = "12345", nome = "O Senhor dos Anéis" }, JsonRequestBehavior.AllowGet);
        }


        //ContentResult - representa um resultado de texto.
        public ActionResult OlaMundo()
        {
            return Content("Olá, Mundo!");
            //não é actionresult, logo é encapsulado em contentresult
            //return "Olá, Mundo!"; 
        }

        //FilePathResult - representa um arquivo para download(com um caminho).
        public ActionResult Logo()
        {
            var path = Server.MapPath("~/Images/gama.png");
            var contentType = "data:image/png;base64,{0}";
            return File(path, contentType, "logo.png");
        }

        //Todos esses resultados de ação são herdados
        //da classe ActionResult base.
    }
}