using System;
using System.Collections.Generic;

namespace Strategy.RealWorld
{
    
    /// <image src="$(ProjectDir)/drill2.png" scale =".5"/>
    /// <image src="$(ProjectDir)/drill3.png" scale =".5"/>
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

            sortedList.SetSortStrategy(new QuickSort());
            sortedList.Sort();

            sortedList.SetSortStrategy(new BubbleSort());
            sortedList.Sort();

            sortedList.SetSortStrategy(new MergeSort());
            sortedList.Sort();

            // Aguarde o usuário

            Console.ReadKey();
        }
    }

    /// <summary>
    /// A classe de "contexto" (FURADEIRA)
    /// </summary>

    public class SortedList
    {
        private List<string> list = new List<string>();
        private SortStrategy sortStrategy;

        public void SetSortStrategy(SortStrategy sortStrategy)
        {
            this.sortStrategy = sortStrategy;
        }

        public void Add(string name)
        {
            list.Add(name);
        }

        public void Sort()
        {
            //list.Sort();
            Console.WriteLine(sortStrategy.GetDescription());
            var ordenado = sortStrategy.Sort(list);

            // Percorrer a lista e exibir os resultados
            foreach (string nome in ordenado)
            {
                Console.WriteLine(" " + nome);
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// A classe abstrata "Estratégia"
    /// </summary>
    public abstract class SortStrategy
    {
        public abstract string GetDescription();
        public abstract IEnumerable<string> Sort(List<string> list);
    }

    /// <summary>
    /// Uma classe "Estratégia" concreta
    /// </summary>
    public class QuickSort : SortStrategy
    {
        public override string GetDescription()
        {
            return "Quicksort: execuções de particionamento.";
        }

        public override IEnumerable<string> Sort(List<string> list)
        {
            var algoritmo = new SmartSorting.Algorithms.QuickSort<string>();
            return algoritmo.Sort(list, SmartSorting.Structure.ESortOrder.Ascending);
        }
    }

    /// <summary>
    /// Uma classe "Estratégia" concreta
    /// </summary>
    public class BubbleSort : SortStrategy
    {
        public override string GetDescription()
        {
            return "BubbleSort: ordenação por bolha";
        }

        public override IEnumerable<string> Sort(List<string> list)
        {
            var algoritmo = new SmartSorting.Algorithms.BubbleSort<string>();
            return algoritmo.Sort(list, SmartSorting.Structure.ESortOrder.Ascending);
        }
    }

    /// <summary>
    /// Uma classe "Estratégia" concreta
    /// </summary>
    public class MergeSort : SortStrategy
    {
        public override string GetDescription()
        {
            return "MergeSort: ordenação por divisão e conquista.";
        }

        public override IEnumerable<string> Sort(List<string> list)
        {
            var algoritmo = new SmartSorting.Algorithms.MergeSort<string>();
            return algoritmo.Sort(list, SmartSorting.Structure.ESortOrder.Ascending);
        }
    }
}
