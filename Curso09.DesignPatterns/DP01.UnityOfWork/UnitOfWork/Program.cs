using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Entities;

namespace UnitOfWork
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaAlunos();
        }

        private static void ListaAlunos()
        {
            Console.WriteLine("Lista Alunos");
            Console.WriteLine("============");
            IEnumerable<Aluno> alunos = GetAlunos();
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"Aluno: id={aluno.ID}, nome={aluno.Nome} {aluno.Sobrenome}");
            }
        }

        private static IEnumerable<Aluno> GetAlunos()
        {
            List<Aluno> alunos;
            using (var context = new EscolaEntities())
            {
                alunos = context.Alunos.ToList();
            }

            return alunos;
        }
    }
}
