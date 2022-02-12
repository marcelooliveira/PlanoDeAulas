using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIFirstClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CriaUmaNovaTarefa(new TodoItem(1, "Ir ao mercado"));
            await CriaUmaNovaTarefa(new TodoItem(2, "Comprar café"));
            await CriaUmaNovaTarefa(new TodoItem(3, "Preparar a mesa"));
            await CriaUmaNovaTarefa(new TodoItem(4, "Fazer café"));

            await ObtemUmaTarefa(4);

            await AtualizaUmaTarefa(new TodoItem(2, "Comprar café e salgados"));

            await RemoveUmaTarefa(2);

            await ListaTodasAsTarefas();

            Console.ReadLine();
        }

        private static async Task CriaUmaNovaTarefa(TodoItem item)
        {
            Console.WriteLine("HTTP.POST: Cria Uma Nova Tarefa");
            Console.WriteLine("======================");
            using (var client = new RestClient("http://localhost:5001"))
            {
                var request = new RestRequest("Todo", Method.Post);
                request.AddBody(item);
                var response = await client.ExecutePostAsync<TodoItem>(request);
                Console.WriteLine($"Id: {response.Data.Id} - Nome: {response.Data.Name}");
                Console.WriteLine();
            }
        }

        private static async Task AtualizaUmaTarefa(TodoItem item)
        {
            Console.WriteLine("HTTP.PUT: Atualiza Uma Tarefa");
            Console.WriteLine("======================");
            using (var client = new RestClient("http://localhost:5001"))
            {
                var request = new RestRequest("Todo", Method.Put);
                request.AddBody(item);
                var response = await client.ExecutePutAsync<TodoItem>(request);
                Console.WriteLine($"Id: {response.Data.Id} - Nome: {response.Data.Name}");
                Console.WriteLine();
            }
        }

        private static async Task RemoveUmaTarefa(int id)
        {
            Console.WriteLine("HTTP.DELETE: Remove Uma Tarefa");
            Console.WriteLine("======================");
            using (var client = new RestClient("http://localhost:5001"))
            {
                var request = new RestRequest($"Todo/{id}", Method.Delete);
                var response = await client.DeleteAsync<TodoItem>(request);
                Console.WriteLine($"Id: {response.Id} - Nome: {response.Name}");
                Console.WriteLine();
            }
        }

        private static async Task ObtemUmaTarefa(int id)
        {
            Console.WriteLine("HTTP.GET: Obtém Uma Tarefa");
            Console.WriteLine("======================");
            using (var client = new RestClient("http://localhost:5001"))
            {
                var request = new RestRequest($"Todo/{id}", Method.Get);
                var response = await client.GetAsync<TodoItem>(request);
                Console.WriteLine($"Id: {response.Id} - Nome: {response.Name}");
                Console.WriteLine();
            }
        }

        private static async Task ListaTodasAsTarefas()
        {
            Console.WriteLine("HTTP.GET: Lista todas as tarefas");
            Console.WriteLine("======================");
            using (var client = new RestClient("http://localhost:5001"))
            {
                var request = new RestRequest("Todo/GetAll", Method.Get);
                var response = await client.ExecuteGetAsync<List<TodoItem>>(request);
                foreach (var item in response.Data)
                {
                    Console.WriteLine($"Id: {item.Id} - Nome: {item.Name}");
                }
                Console.WriteLine();
                Console.WriteLine($"{response.Data.Count} tarefas.");
                Console.WriteLine();
            }
        }
    }
}
