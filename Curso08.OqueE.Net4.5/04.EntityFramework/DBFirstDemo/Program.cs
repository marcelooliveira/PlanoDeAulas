using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new LojaEntities())
            {
                // Cria e salva clientes e pedidos
                Cliente cliente1 = new Cliente
                {
                    Nome = "Smeagol",
                    Email = "smeagol@golum.com"
                };
                db.Clientes.Add(cliente1);
                db.SaveChanges();

                Cliente cliente2 = new Cliente
                {
                    Nome = "Harry Potter",
                    Email = "harry@potter.com"
                };
                db.Clientes.Add(cliente2);
                db.SaveChanges();

                Cliente cliente3 = new Cliente
                {
                    Nome = "Thanos",
                    Email = "thanos@inevitable.com"
                };
                db.Clientes.Add(cliente3);
                db.SaveChanges();

                cliente1.Pedidoes.Add(new Pedido
                {
                    Item = "Precioso",
                    Preco = 1000
                });

                cliente2.Pedidoes.Add(new Pedido
                {
                    Item = "Nimbus 2000",
                    Preco = 4000
                });

                cliente3.Pedidoes.Add(new Pedido
                {
                    Item = "Joias do infinito",
                    Preco = 1000000
                });

                var query = from c in db.Clientes.Include("Pedidoes")
                            select c;

                foreach (var cliente in query)
                {
                    Console.WriteLine($"Cliente: {cliente.Nome}");
                    Console.WriteLine("Pedidos:");
                    Console.WriteLine("========");
                    foreach (var p in cliente.Pedidoes)
                    {
                        Console.WriteLine($"Item: {p.Item}, Preço: {p.Preco}");
                    }
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
