//using SCA_Console.Data;
using SCA_Console.Models;

namespace SCA_Console.Repository
{
    public class DisciplinaRepository
    {
        //private readonly SCAdbContext _context;

        //public DisciplinaRepository(SCAdbContext context)
        //{
        //    _context = context;
        //}

        public readonly List<Disciplina> listaDisciplinas = new List<Disciplina>();

        public void CriarDisciplina(Disciplina disciplina)
        {
            listaDisciplinas.Add(disciplina);
        }

        public void ExcluirDisciplina(Disciplina disciplina)
        {
            listaDisciplinas.Remove(disciplina);
        }
    }
}
