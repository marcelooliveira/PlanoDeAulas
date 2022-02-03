using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<List<TodoItem>> GetAllAsync()
        {
            await Task.Delay(1000);
            return GetAll();
        }

        public TodoItem Get(int id)
        {
            return todoItems
                .Where(i => i.Key == id)
                .Select(i => i.Value)
                .SingleOrDefault();
        }

        public async Task<TodoItem> GetAsync(int id)
        {
            await Task.Delay(1000);
            return Get(id);
        }

        public TodoItem Create(TodoItem item)
        {
            int id = GetNextId();
            var newItem = new TodoItem(id, item.Name);
            todoItems.Add(id, newItem);
            return newItem;
        }

        public async Task<TodoItem> CreateAsync(TodoItem item)
        {
            await Task.Delay(1000);
            return Create(item);
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

        public async Task<TodoItem> SaveAsync(TodoItem item)
        {
            await Task.Delay(1000);
            return Save(item);
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

        public async Task<TodoItem> DeleteAsync(int id)
        {
            await Task.Delay(1000);
            return Delete(id);
        }
    }
}
