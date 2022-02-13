using System;
using System.Collections.Generic;

namespace Strategy.RealWorld
{
    
    /// <image src="$(ProjectDir)/drill2 .png" scale =".5"/>
    /// <image src="$(ProjectDir)/drill3 .png" scale =".5"/>
    /// <image src="$(ProjectDir)/strategy .png"/>

    /// <summary>
    /// Padrão de Design Estratégia
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            // Dois contextos seguindo estratégias diferentes

            SortedList sortedList = new SortedList();

            sortedList.Add("Saulo");
            sortedList.Add("Janaelton");
            sortedList.Add("Luan");
            sortedList.Add("Adriano");
            sortedList.Add("Aline");

            sortedList.Sort();

            // Aguarde o usuário

            Console.ReadKey();
        }
    }

    /// <summary>
    /// A classe de "contexto"
    /// </summary>

    public class SortedList
    {
        private List<string> list = new List<string>();

        public void Add(string name)
        {
            list.Add(name);
        }

        public void Sort()
        {
            list.Sort();

            // Percorrer a lista e exibir os resultados
            foreach (string nome in list)
            {
                Console.WriteLine(" " + nome);
            }
            Console.WriteLine();
        }
    }
}
