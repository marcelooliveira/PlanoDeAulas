namespace UnitOfWork.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Matricula")]
    public partial class Matricula
    {
        public int MatriculaID { get; set; }

        public int CursoID { get; set; }

        public int AlunoID { get; set; }

        public int? Nota { get; set; }

        public virtual Aluno Aluno { get; set; }

        public virtual Curso Curso { get; set; }
    }
}
