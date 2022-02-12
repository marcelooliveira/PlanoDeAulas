using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PadraoMVC.Controllers
{
    public class LivrosController : Controller
    {
        //ex 1: /livros
        //ex 2: /livros/143978
        [Route("livros/{isbn?}")]
        public ActionResult Get(string isbn)
        {
            if (!string.IsNullOrEmpty(isbn))
            {
                return Content("livro específico: " + isbn);
            }

            return Content("todos os livros.");
        }

        // ex 1: /livros/idioma
        // ex 2: /livros/idioma/en
        // ex 3: /livros/idioma/de
        [Route("livros/idioma/{idioma=ptBR}")]
        public ActionResult GetByLanguage(string idioma)
        {
            return Content($"Todos os livros no idioma: {idioma}");
        }

        //livros/autor/5
        [Route("livros/autor/{id:int}")]
        public ActionResult GetAuthorById(int id)
        {
            return Content($"Livros do autor com id = {id}");
        }

        //livros/autor/Tolkien
        [Route("livros/autor/{name}")]
        public ActionResult GetAuthorByName(string name)
        {
            return Content($"Livros do autor com nome = {name}");
        }
    }
}