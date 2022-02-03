using APIFirstDemo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<TodoItem>> PostAsync([FromBody]TodoItem item)
        {
            return Ok(await service.CreateAsync(item));
        }

        /// <summary>
        /// Obtém uma tarefa por Id
        /// </summary>
        /// <param name="id">Id da tarefa</param>
        /// <returns>Tarefa retornada</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetAsync(int id)
        {
            return Ok(await service.GetAsync(id));
        }

        /// <summary>
        /// Cria ou modifica uma tarefa
        /// </summary>
        /// <param name="item">Tarefa a ser criada ou atualizada</param>
        /// <returns>Tarea criada ou atualizada</returns>
        [HttpPut]
        public async Task<ActionResult<TodoItem>> PutAsync(TodoItem item)
        {
            return Ok(await service.SaveAsync(item));
        }

        /// <summary>
        /// Remove uma tarefa
        /// </summary>
        /// <param name="id">Tarefa a ser removida</param>
        /// <returns>Tarefa que foi removida</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteAsync(int id)
        {
            return Ok(await service.DeleteAsync(id));
        }

        /// <summary>
        /// Obtém todas as tarefas
        /// </summary>
        /// <returns>Lista das tarefas retornadas</returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<TodoItem>>> GetAllAsync()
        {
            return Ok(await service.GetAllAsync());
        }
    }
}
