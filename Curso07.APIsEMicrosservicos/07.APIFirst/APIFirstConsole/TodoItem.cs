using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFirstClient
{
    public class TodoItem
    {
        public TodoItem(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
