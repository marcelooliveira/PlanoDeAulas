using APIFirstDemo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APIFirstDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TodoController : ControllerBase
    {
        static Dictionary<int, TodoItem> todoItems 
            = new Dictionary<int, TodoItem>();

        /// <summary>
        /// Obtém todas as tarefas
        /// </summary>
        /// <returns>Lista de tarefas</returns>
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<TodoItem>> Get()
        {
            return todoItems.Values.ToList();
        }

        /// <summary>
        /// Obtém uma tarefa por Id
        /// </summary>
        /// <param name="id">Id da tarefa</param>
        /// <returns>Uma tarefa</returns>
        [HttpGet]
        public ActionResult<TodoItem> Get(int id)
        {
            return Ok(todoItems
                .Where(i => i.Key == id)
                .Select(i => i.Value)
                .SingleOrDefault());
        }

        /// <summary>
        /// Cria uma nova tarefa
        /// </summary>
        /// <param name="item">Dados da tarefa</param>
        /// <returns>tarefa criada</returns>
        [HttpPost]
        public ActionResult<TodoItem> Post([FromBody] TodoItem item)
        {
            int id = GetNextId();
            item = new TodoItem(id, item.Name);
            todoItems.Add(id, item);
            return Ok(item);
        }

        private static int GetNextId()
        {
            int id = 0;
            var last = todoItems.Values.LastOrDefault();
            if (last != null)
            {
                id = last.Id;
            }
            id++;
            return id;
        }

        /// <summary>
        /// Cria ou modifica uma tarefa
        /// </summary>
        /// <param name="item">Dados da tarefa</param>
        /// <returns>Dados da tarefa criada ou modificada</returns>
        [HttpPut]
        public ActionResult<TodoItem> Put([FromBody] TodoItem item)
        {
            if (todoItems.ContainsKey(item.Id))
            {
                todoItems[item.Id] = item;
                return Ok(item);
            }
            else
            {
                int id = GetNextId();
                var newItem = new TodoItem(id, item.Name);
                todoItems.Add(id, newItem);
                return Ok(newItem);
            }
        }

        /// <summary>
        /// Remove uma tarefa
        /// </summary>
        /// <param name="id">Id da Tarefa</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<TodoItem> Delete(int id)
        {
            if (todoItems.ContainsKey(id))
            {
                var item = todoItems[id];
                todoItems.Remove(id);
                return Ok(item);
            }

            return Ok();
        }
    }
}
