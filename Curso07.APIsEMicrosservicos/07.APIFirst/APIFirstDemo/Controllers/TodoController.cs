using APIFirstDemo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Telemetria_ServiceA.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TodoController : ControllerBase
    {
        static Dictionary<int, TodoItem> todoItems 
            = new Dictionary<int, TodoItem>();

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<TodoItem>> Get()
        {
            return todoItems.Values.ToList();
        }

        [HttpGet]
        public ActionResult<TodoItem> Get(int id)
        {
            return Ok(todoItems
                .Where(i => i.Key == id)
                .Select(i => i.Value)
                .SingleOrDefault());
        }

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

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (todoItems.ContainsKey(id))
            {
                todoItems.Remove(id);
            }

            return Ok();
        }
    }
}
