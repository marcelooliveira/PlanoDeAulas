using CodeFirstDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.DAL
{
    public class EscolaInitializer :
        System.Data.Entity.DropCreateDatabaseIfModelChanges<EscolaContext>
    {
        protected override void Seed(EscolaContext context)
        {
            var Alunos = new List<Aluno>
            {
                new Aluno{Nome="Carlos",Sobrenome="Alcantara",DataMatricula=DateTime.Parse("2005-09-01")},
                new Aluno{Nome="Melissa",Sobrenome="Alves",DataMatricula=DateTime.Parse("2002-09-01")},
                new Aluno{Nome="Artur",Sobrenome="Andrade",DataMatricula=DateTime.Parse("2003-09-01")},
                new Aluno{Nome="Jessica",Sobrenome="Bastos",DataMatricula=DateTime.Parse("2002-09-01")},
                new Aluno{Nome="Jana",Sobrenome="Luz",DataMatricula=DateTime.Parse("2002-09-01")},
                new Aluno{Nome="Penelope",Sobrenome="Justino",DataMatricula=DateTime.Parse("2001-09-01")},
                new Aluno{Nome="Laura",Sobrenome="Noronha",DataMatricula=DateTime.Parse("2003-09-01")},
                new Aluno{Nome="Nilson",Sobrenome="Oliveira",DataMatricula=DateTime.Parse("2005-09-01")}
            };

            Alunos.ForEach(s => context.Alunos.Add(s));
            context.SaveChanges();

            var courses = new List<Curso>
            {
                new Curso{CursoID=1050,Titulo="Química",Creditos=3,},
                new Curso{CursoID=4022,Titulo="Microeconomia",Creditos=3,},
                new Curso{CursoID=4041,Titulo="Macroeconomia",Creditos=3,},
                new Curso{CursoID=1045,Titulo="Cálculo",Creditos=4,},
                new Curso{CursoID=3141,Titulo="Trigonometria",Creditos=4,},
                new Curso{CursoID=2021,Titulo="Composição",Creditos=3,},
                new Curso{CursoID=2042,Titulo="Literatura",Creditos=4,}
            };
            courses.ForEach(s => context.Cursos.Add(s));
            context.SaveChanges();

            var matriculas = new List<Matricula>
            {
                new Matricula{AlunoID=1,CursoID=1050,Nota=Nota.A},
                new Matricula{AlunoID=1,CursoID=4022,Nota=Nota.C},
                new Matricula{AlunoID=1,CursoID=4041,Nota=Nota.B},
                new Matricula{AlunoID=2,CursoID=1045,Nota=Nota.B},
                new Matricula{AlunoID=2,CursoID=3141,Nota=Nota.F},
                new Matricula{AlunoID=2,CursoID=2021,Nota=Nota.F},
                new Matricula{AlunoID=3,CursoID=1050},
                new Matricula{AlunoID=4,CursoID=1050},
                new Matricula{AlunoID=4,CursoID=4022,Nota=Nota.F},
                new Matricula{AlunoID=5,CursoID=4041,Nota=Nota.C},
                new Matricula{AlunoID=6,CursoID=1045},
                new Matricula{AlunoID=7,CursoID=3141,Nota=Nota.A},
            };
            matriculas.ForEach(s => context.Matriculas.Add(s));
            context.SaveChanges();
        }
    }
}
