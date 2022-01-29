using System.Collections.Generic;
using System.Linq;

namespace APIFirstDemo
{
    public class TodoService
    {
        static Dictionary<int, TodoItem> todoItems 
            = new Dictionary<int, TodoItem>();

        public static int GetNextId()
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

        public List<TodoItem> GetAll()
        {
            return todoItems.Values.ToList();
        }

        public TodoItem Get(int id)
        {
            return todoItems
                .Where(i => i.Key == id)
                .Select(i => i.Value)
                .SingleOrDefault();
        }

        public TodoItem Create(TodoItem item)
        {
            int id = GetNextId();
            var newItem = new TodoItem(id, item.Name);
            todoItems.Add(id, newItem);
            return newItem;
        }

        public TodoItem Save(TodoItem item)
        {
            if (todoItems.ContainsKey(item.Id))
            {
                todoItems[item.Id] = item;
                return item;
            }
            else
            {
                int id = GetNextId();
                var newItem = new TodoItem(id, item.Name);
                todoItems.Add(id, newItem);
                return newItem;
            }
        }

        public TodoItem Delete(int id)
        {
            TodoItem item = null;
            if (todoItems.ContainsKey(id))
            {
                item = todoItems[id];
                todoItems.Remove(id);
            }
            return item;
        }
    }
}
