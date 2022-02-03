using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Cafe xicara = ServirCafe();
            Console.WriteLine("CAFÉ ESTÁ PRONTO");


            Task<Ovo> ovosTask = FritarOvosAsync(2);
            //Ovo ovos = await FritarOvosAsync(2);

            Task<Bacon> baconTask = FritarBaconAsync(3);
            //Bacon bacon = await FritarBaconAsync(3);


            Torrada torrada = await TorrarPaoAsync(2);
            PassarManteiga(torrada);
            PassarGeleia(torrada);
            Console.WriteLine("TORRADA ESTÁ PRONTA");

            Suco suco = ServirSuco();
            Console.WriteLine("SUCO DE LARANJA ESTÁ PRONTO");

            Ovo ovos = await ovosTask;
            Console.WriteLine("OVOS ESTÃO PRONTOS");

            Bacon bacon = await baconTask;
            Console.WriteLine("BACON ESTÁ PRONTO");

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

        private static async Task<Torrada> TorrarPaoAsync(int fatias)
        {
            Console.WriteLine();
            for (int fatia = 0; fatia < fatias; fatia++)
            {
                Console.WriteLine("Inserindo uma fatia de pão na torradeira");
            }
            Console.WriteLine("Aquecendo a torradeira...");
            //Thread.Sleep(3000); //BLOQUEIA!!!
            await Task.Delay(3000); //AGUARDA, SEM BLOQUEAR!!!
            Console.WriteLine("Retire a fatia da torradeira");

            return new Torrada();
        }

        private static async Task<Bacon> FritarBaconAsync(int fatias)
        {
            Console.WriteLine();
            Console.WriteLine($"inserindo {fatias} fatias de bacon na panela");
            Console.WriteLine("fritando o primeiro lado do bacon...");
            //Thread.Sleep(3000); //BLOQUEIA A THREAD!!!
            await Task.Delay(3000); //AGUARDA MAS NÃO BLOQUEIA!
            for (int fatia = 0; fatia < fatias; fatia++)
            {
                Console.WriteLine("virando o bacon");
            }
            Console.WriteLine("fritando o segundo lado do bacon...");
            //Thread.Sleep(3000);
            await Task.Delay(3000); //AGUARDA MAS NÃO BLOQUEIA!

            Console.WriteLine("Coloque o bacon no prato");

            return new Bacon();
        }

        private static async Task<Ovo> FritarOvosAsync(int numOvos)
        {
            Console.WriteLine();
            Console.WriteLine("Aquecendo a panela...");
            //Thread.Sleep(3000); //BLOQUEIA A THREAD!!
            await Task.Delay(3000); //AGUARDA MAS NÃO BLOQUEIA!

            Console.WriteLine($"quebrando {numOvos} ovos");
            Console.WriteLine("fritando os ovos ...");
            //Thread.Sleep(3000);
            await Task.Delay(3000); //AGUARDA MAS NÃO BLOQUEIA!

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