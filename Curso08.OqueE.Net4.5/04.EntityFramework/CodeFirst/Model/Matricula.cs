using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Model
{
    public class Matricula
    {
        public int MatriculaID { get; set; }
        public int CursoID { get; set; }
        public int AlunoID { get; set; }
        public Nota? Nota { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual Aluno Aluno { get; set; }
    }
}
