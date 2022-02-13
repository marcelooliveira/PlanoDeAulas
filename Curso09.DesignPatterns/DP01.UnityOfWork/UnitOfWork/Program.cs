using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.DAL;
using UnitOfWork.Entities;

namespace UnitOfWork
{
    class Program
    {
        private static UnitOfWork.DAL.UnitOfWork unitOfWork
            = new DAL.UnitOfWork();
        static void Main(string[] args)
        {


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
            
            unitOfWork.Dispose();
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

        private static IEnumerable<Aluno> GetAlunos()
        {
            return unitOfWork.AlunoRepository.GetAll().ToList();
        }

        public static Aluno GetAlunoByID(int id)
        {
            return unitOfWork.AlunoRepository.GetById(id);
        }

        public static Aluno FindAlunoByName(string name)
        {
            return unitOfWork.AlunoRepository.Find(e => e.Nome == name);
        }

        public static Aluno InsertAluno(Aluno aluno)
        {
            return unitOfWork.AlunoRepository.Insert(aluno);
        }

        public static void DeleteAluno(int alunoID)
        {
            unitOfWork.AlunoRepository.Delete(alunoID);
        }

        public static void UpdateAluno(Aluno aluno)
        {
            unitOfWork.AlunoRepository.Update(aluno);
        }

        public static void Save()
        {
            unitOfWork.AlunoRepository.Save();
        }
    }
}
