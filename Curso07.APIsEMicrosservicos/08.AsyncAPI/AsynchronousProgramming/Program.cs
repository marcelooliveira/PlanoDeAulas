using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    class Program
    {
        static void Main(string[] args)
        {
            Cafe xicara = ServirCafe();
            Console.WriteLine("CAFÉ ESTÁ PRONTO");

            Ovo ovos = FritarOvos(2);
            Console.WriteLine("OVOS ESTÃO PRONTOS");

            Bacon bacon = FritarBacon(3);
            Console.WriteLine("BACON ESTÁ PRONTO");

            Torrada torrada = TorrarPao(2);
            PassarManteiga(torrada);
            PassarGeleia(torrada);
            Console.WriteLine("TORRADA ESTÁ PRONTA");

            Suco suco = ServirSuco();
            Console.WriteLine("SUCO DE LARANJA ESTÁ PRONTO");

            Console.WriteLine();
            Console.WriteLine("CAFÉ DA MANHÃ ESTÁ PRONTO!");

            Console.ReadLine();
        }

        private static Suco ServirSuco()
        {
            Console.WriteLine();
            Console.WriteLine("servindo suco de laranja");
            return new Suco();
        }

        private static void PassarGeleia(Torrada torrada)
        {
            Console.WriteLine("Passando geleia na torrada");
        }

        private static void PassarManteiga(Torrada torrada)
        {
            Console.WriteLine("Passando manteiga na torrada");
        }

        private static Torrada TorrarPao(int fatias)
        {
            Console.WriteLine();
            for (int fatia = 0; fatia < fatias; fatia++)
            {
                Console.WriteLine("Inserindo uma fatia de pão na torradeira");
            }
            Console.WriteLine("Aquecendo a torradeira...");
            Thread.Sleep(3000);
            Console.WriteLine("Retire a fatia da torradeira");

            return new Torrada();
        }

        private static Bacon FritarBacon(int fatias)
        {
            Console.WriteLine();
            Console.WriteLine($"inserindo {fatias} fatias de bacon na panela");
            Console.WriteLine("fritando o primeiro lado do bacon...");
            Thread.Sleep(3000);
            for (int fatia = 0; fatia < fatias; fatia++)
            {
                Console.WriteLine("virando o bacon");
            }
            Console.WriteLine("fritando o segundo lado do bacon...");
            Thread.Sleep(3000);
            Console.WriteLine("Coloque o bacon no prato");

            return new Bacon();
        }

        private static Ovo FritarOvos(int numOvos)
        {
            Console.WriteLine();
            Console.WriteLine("Aquecendo a panela...");
            Thread.Sleep(3000);
            Console.WriteLine($"quebrando {numOvos} ovos");
            Console.WriteLine("fritando os ovos ...");
            Thread.Sleep(3000);
            Console.WriteLine("Coloque os ovos no prato");

            return new Ovo();
        }

        private static Cafe ServirCafe()
        {
            Console.WriteLine();
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