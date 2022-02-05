using CodeFirstDemo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: criar pasta Model
            //TODO: criar modelo Curso (CursoID, Titulo, Creditos, *Matriculas)
            //TODO: criar enum Nota (A, B, C, D, F)
            //TODO: criar modelo Matricula (MatriculaID, CursoID, AlunoID, Nota, *Curso, *Student)
            //TODO: criar modelo de Aluno (ID, Nome, Sobrenome, DataMatricula, *Matriculas)
            //TODO: Curso: id vai ser gerado manualmente
            //TODO: criar pasta DAL
            //TODO: criar EscolaContext (Alunos, Matriculas, Cursos)
            //TODO: criar EscolaInitializer
            //TODO: criar e inicializar banco de dados

            Console.WriteLine("Criando e Inicializando banco de dados a partir do código C#...");
            using (EscolaContext db = new EscolaContext())
            {
                new EscolaInitializer().InitializeDatabase(db);
            }
            Console.WriteLine("Concluído!");
            Console.ReadKey();
        }
    }
}
