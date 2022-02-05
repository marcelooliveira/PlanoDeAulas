using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstDemo.Model
{
    public class Aluno
    {
        public int ID { get; set; }
        public string Sobrenome { get; set; }
        public string Nome { get; set; }
        public DateTime DataMatricula { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }
    }

    public enum Nota
    {
        A, B, C, D, F
    }

    public class Matricula
    {
        public int MatriculaID { get; set; }
        public int CursoID { get; set; }
        public int AlunoID { get; set; }
        public Nota? Nota { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual Aluno Student { get; set; }
    }

    public class Curso
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CursoID { get; set; }
        public string Titulo { get; set; }
        public int Creditos { get; set; }

        public virtual ICollection<Matricula> Enrollments { get; set; }
    }
}

