using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Entities;

namespace UnitOfWork.DAL
{
    public class UnitOfWork : IDisposable
    {
        private EscolaContext context = new EscolaContext();
        
        private GenericRepository<Aluno> alunoRepository;
        public GenericRepository<Aluno> AlunoRepository
        {
            get
            {
                if (alunoRepository == null)
                {
                    alunoRepository = new GenericRepository<Aluno>(context);
                }
                return alunoRepository;
            }
        }

        private GenericRepository<Curso> cursoRepository;
        public GenericRepository<Curso> CursoRepository
        {
            get
            {
                if (cursoRepository == null)
                {
                    cursoRepository = new GenericRepository<Curso>(context);
                }
                return cursoRepository;
            }
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
