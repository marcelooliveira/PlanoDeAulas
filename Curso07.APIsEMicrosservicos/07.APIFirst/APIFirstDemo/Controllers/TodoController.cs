using APIFirstDemo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace APIFirstDemo.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class TodoController : ControllerBase
    {
        private readonly TodoService service = new TodoService();

        /// <summary>
        /// Cria uma nova tarefa
        /// </summary>
        /// <param name="item">Dados da tarefa</param>
        /// <returns>tarefa criada</returns>
        [HttpPost]
        public ActionResult<TodoItem> Post([FromBody] TodoItem item)
        {
            return Ok(service.Create(item));
        }

        /// <summary>
        /// Obtém uma tarefa por Id
        /// </summary>
        /// <param name="id">Id da tarefa</param>
        /// <returns>Uma tarefa</returns>
        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            return Ok(service.Get(id));
        }

        /// <summary>
        /// Cria ou modifica uma tarefa
        /// </summary>
        /// <param name="item">Dados da tarefa</param>
        /// <returns>Dados da tarefa criada ou modificada</returns>
        [HttpPut]
        public ActionResult<TodoItem> Put([FromBody] TodoItem item)
        {
            return Ok(service.Save(item));
        }

        /// <summary>
        /// Remove uma tarefa
        /// </summary>
        /// <param name="id">Id da Tarefa</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<TodoItem> Delete(int id)
        {
            return Ok(service.Delete(id));
        }

        /// <summary>
        /// Obtém todas as tarefas
        /// </summary>
        /// <returns>Lista de tarefas</returns>
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<TodoItem>> GetAll()
        {
            return Ok(service.GetAll());
        }
    }
}
