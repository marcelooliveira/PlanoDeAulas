using System;
using System.Collections.Generic;
using static System.Console;

namespace Singleton.NetOptimized
{
    public class Program
    {
        /// <summary>
        /// Singleton Design Pattern
        /// </summary>

        public static void Main()
        {
            var b1 = new DatabaseConnection();
            var b2 = new DatabaseConnection();
            var b3 = new DatabaseConnection();
            var b4 = new DatabaseConnection();

            // Confirma se os objetos são a mesma instância

            var resultado1 = b1.ExecutaQuery("SELECT * FROM ALUNOS");
            Console.WriteLine(resultado1);
            var resultado2 = b2.ExecutaQuery("SELECT * FROM PROFESSORES");
            Console.WriteLine(resultado2);
            var resultado3 = b3.ExecutaQuery("SELECT * FROM CURSOS");
            Console.WriteLine(resultado3);
            var resultado4 = b4.ExecutaQuery("SELECT * FROM AULAS");
            Console.WriteLine(resultado4);

            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                WriteLine("Objetos são da mesma instância!\n");
            }
            else
            {
                WriteLine("Objetos são instâncias diferentes!\n");
            }

            ReadKey();
        }
    }

    /// <summary>
    /// The 'Singleton' class
    /// </summary>

    public sealed class DatabaseConnection
    {
        public DatabaseConnection()
        {

        }

        public string ExecutaQuery(string query)
        {
            return "Query executada com sucesso!";
        }
    }

    /// <summary>
    /// Representa um servidor
    /// </summary>

    public class Server
    {
        public string Name { get; set; }
        public string IP { get; set; }
    }
}

