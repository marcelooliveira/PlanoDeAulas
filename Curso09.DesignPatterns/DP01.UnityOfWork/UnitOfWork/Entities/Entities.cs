using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace UnitOfWork.Entities
{
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Escola")
        {
        }

        public virtual DbSet<Aluno> Alunoes { get; set; }
        public virtual DbSet<Curso> Cursoes { get; set; }
        public virtual DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
