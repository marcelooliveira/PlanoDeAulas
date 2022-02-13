using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace UnitOfWork.Entities
{
    public partial class EscolaEntities : DbContext
    {
        public EscolaEntities()
            : base("name=Escola")
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
