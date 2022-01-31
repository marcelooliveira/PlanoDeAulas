using APIFirstDemo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace APIFirstDemo.Controllers
{
    /// <summary>
    /// Operações para criar, obter, atualizar e remover tarefas (TO-DO LIST)
    /// </summary>
    [ApiController]
    [Route("[controller]")]

    public class TodoController : ControllerBase
    {
        private readonly TodoService service = new TodoService();

        /// <summary>
        /// Cria uma nova tarefa
        /// </summary>
        /// <param name="item">dados da tarefa</param>
        /// <returns>tarefa criada</returns>
        [HttpPost]
        public ActionResult<TodoItem> Post([FromBody]TodoItem item)
        {
            return Ok(service.Create(item));
        }

        /// <summary>
        /// Obtém uma tarefa por Id
        /// </summary>
        /// <param name="id">Id da tarefa</param>
        /// <returns>Tarefa retornada</returns>
        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            return Ok(service.Get(id));
        }

        /// <summary>
        /// Cria ou modifica uma tarefa
        /// </summary>
        /// <param name="item">Tarefa a ser criada ou atualizada</param>
        /// <returns>Tarea criada ou atualizada</returns>
        [HttpPut]
        public ActionResult<TodoItem> Put(TodoItem item)
        {
            return Ok(service.Save(item));
        }

        /// <summary>
        /// Remove uma tarefa
        /// </summary>
        /// <param name="id">Tarefa a ser removida</param>
        /// <returns>Tarefa que foi removida</returns>
        [HttpDelete("{id}")]
        public ActionResult<TodoItem> Delete(int id)
        {
            return Ok(service.Delete(id));
        }

        /// <summary>
        /// Obtém todas as tarefas
        /// </summary>
        /// <returns>Lista das tarefas retornadas</returns>
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<TodoItem>> GetAll()
        {
            return Ok(service.GetAll());
        }
    }
}
