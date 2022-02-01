using System;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    class Program
    {
        static void Main(string[] args)
        {
            Cafe xicara = ServirCafe();
            Console.WriteLine("café está pronto");

            Ovo ovos = FritarOvos(2);
            Console.WriteLine("ovos estão prontos");

            Bacon bacon = FritarBacon(3);
            Console.WriteLine("bacon está pronto");

            Torrada torrada = TorrarPao(2);
            PassarManteiga(torrada);
            PassarGeleia(torrada);
            Console.WriteLine("torrada está pronta");

            Suco suco = ServirSuco();
            Console.WriteLine("suco de laranja está pronto");
            Console.WriteLine("Café da manhã está pronto!");

            Console.ReadLine();
        }

        private static Suco ServirSuco()
        {
            Console.WriteLine("servindo suco de laranja");
            return new Suco();
        }

        private static void PassarGeleia(Torrada torrada) =>
            Console.WriteLine("Passando geleia na torrada");

        private static void PassarManteiga(Torrada torrada) =>
            Console.WriteLine("Passando manteiga na torrada");

        private static Torrada TorrarPao(int fatias)
        {
            for (int fatia = 0; fatia < fatias; fatia++)
            {
                Console.WriteLine("Inserindo uma fatia de pão na torradeira");
            }
            Console.WriteLine("Aquecendo a torradeira...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Retire a fatia da torradeira");

            return new Torrada();
        }

        private static Bacon FritarBacon(int fatias)
        {
            Console.WriteLine($"inserindo {fatias} fatias de bacon na panela");
            Console.WriteLine("fritando o primeiro lado do bacon...");
            Task.Delay(3000).Wait();
            for (int fatia = 0; fatia < fatias; fatia++)
            {
                Console.WriteLine("virando o bacon");
            }
            Console.WriteLine("fritando o segundo lado do bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Coloque o bacon no prato");

            return new Bacon();
        }

        private static Ovo FritarOvos(int numOvos)
        {
            Console.WriteLine("Aquecendo a panela...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"quebrando {numOvos} ovos");
            Console.WriteLine("fritando os ovos ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Coloque os ovos no prato");

            return new Ovo();
        }

        private static Cafe ServirCafe()
        {
            Console.WriteLine("Servindo café");
            return new Cafe();
        }
    }

    internal class Cafe
    {
    }

    internal class Ovo
    {
    }

    internal class Bacon
    {
    }

    internal class Torrada
    {
    }

    internal class Suco
    {
    }
}