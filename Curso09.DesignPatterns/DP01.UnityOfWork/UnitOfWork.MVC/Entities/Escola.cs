using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace UnitOfWork.MVC.Entities
{
    public partial class Escola : DbContext
    {
        public Escola()
            : base("name=Escola")
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Curso> Cursoes { get; set; }
        public virtual DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
