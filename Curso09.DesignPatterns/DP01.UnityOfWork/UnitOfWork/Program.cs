using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Entities;

namespace UnitOfWork
{
    class Program
    {
        private static EscolaContext context;

        static void Main(string[] args)
        {
            context = new EscolaContext();

            ListaAlunos();

            Console.WriteLine();
            Console.WriteLine("ALTERANDO ALUNO");
            Console.WriteLine("===============");
            var aluno3 = GetAlunoByID(3);
            aluno3.Sobrenome = "Andrade ALTERADO";
            UpdateAluno(aluno3);
            Save();
            ListaAlunos();

            Console.WriteLine();
            Console.WriteLine("ALTERANDO DE VOLTA");
            Console.WriteLine("===============");
            aluno3 = GetAlunoByID(3);
            aluno3.Sobrenome = "Andrade";
            UpdateAluno(aluno3);
            Save();
            ListaAlunos();

            Console.WriteLine();
            Console.WriteLine("INSERINDO ALUNO");
            Console.WriteLine("===============");
            var novoAluno = new Aluno { Nome = "Fulano", Sobrenome = "de Tal", DataMatricula = DateTime.Now };
            InsertAluno(novoAluno);
            Save();

            ListaAlunos();

            Console.WriteLine();
            Console.WriteLine("REMOVENDO ALUNO");
            Console.WriteLine("===============");
            DeleteAluno(novoAluno.ID);
            Save();

            ListaAlunos();
            ListaCursos();

            context.Dispose();
        }

        private static void ListaAlunos()
        {
            Console.WriteLine();
            Console.WriteLine("Lista Alunos");
            Console.WriteLine("============");
            IEnumerable<Aluno> alunos = GetAlunos();
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"Aluno: id={aluno.ID}, nome={aluno.Nome} {aluno.Sobrenome}");
            }
        }

        private static void ListaCursos()
        {
            Console.WriteLine();
            Console.WriteLine("Lista Cursos");
            Console.WriteLine("============");
            IEnumerable<Curso> cursos = GetCursos();
            foreach (var curso in cursos)
            {
                Console.WriteLine($"Cursos: id={curso.ID}, nome={curso.Titulo}");
            }
        }

        private static IEnumerable<Aluno> GetAlunos()
        {
            return context.Alunos.ToList();
        }

        public static Aluno GetAlunoByID(int id)
        {
            return context.Alunos.Find(id);
        }

        public static Aluno FindAlunoByName(string name)
        {
            return context.Alunos.Where(e => e.Nome == name).SingleOrDefault();
        }

        public static Aluno InsertAluno(Aluno aluno)
        {
            return context.Alunos.Add(aluno);
        }

        public static void DeleteAluno(int alunoID)
        {
            Aluno aluno = context.Alunos.Find(alunoID);
            context.Alunos.Remove(aluno);
        }

        public static void UpdateAluno(Aluno aluno)
        {
            context.Entry(aluno).State = EntityState.Modified;
        }

        public static void Save()
        {
            context.SaveChanges();
        }

        private static IEnumerable<Curso> GetCursos()
        {
            return context.Cursos.ToList();
        }

        private static IEnumerable<Matricula> GetMatriculas()
        {
            return context
                .Matriculas
                .Include("Aluno")
                .Include("Curso")
                .ToList();
        }
    }
}
