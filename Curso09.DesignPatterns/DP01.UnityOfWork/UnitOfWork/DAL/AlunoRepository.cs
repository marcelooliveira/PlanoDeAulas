using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Entities;

namespace UnitOfWork.DAL
{
    interface IAlunoRepository : IDisposable
    {
        IEnumerable<Aluno> GetAll();
        Aluno GetById(int id);
        Aluno FindByName(string name);
        Aluno Insert(Aluno aluno);
        void Update(Aluno aluno);
        void Delete(int alunoID);
        void Save();
    }

    public class AlunoRepository : IAlunoRepository
    {
        private EscolaContext context;

        public AlunoRepository(EscolaContext context)
        {
            this.context = context;
        }

        public IEnumerable<Aluno> GetAll()
        {
            return context.Alunos.ToList();
        }
        public Aluno GetById(int id)
        {
            return context.Alunos.Find(id);
        }
        public Aluno FindByName(string name)
        {
            return context.Alunos.Where(e => e.Nome == name).SingleOrDefault();
        }
        public Aluno Insert(Aluno aluno)
        {
            return context.Alunos.Add(aluno);
        }
        public void Update(Aluno aluno)
        {
            context.Entry(aluno).State = EntityState.Modified;
        }
        public void Delete(int alunoID)
        {
            Aluno aluno = context.Alunos.Find(alunoID);
            context.Alunos.Remove(aluno);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
