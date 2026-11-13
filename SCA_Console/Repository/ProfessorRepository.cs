//using SCA_Console.Data;
using SCA_Console.Models;

namespace SCA_Console.Repository
{
    public class ProfessorRepository
    {
        //private readonly SCAdbContext _context;

        //public ProfessorRepository(SCAdbContext context)
        //{
        //    _context = context;
        //}

        public readonly List<Professor> listaProfessores = new List<Professor>();


        public void CriarProfessor(Professor professor)
        {
            listaProfessores.Add(professor);
            //_context.SaveChanges();
        }

        public void ExcluirProfessor(Professor professor)
        {
            listaProfessores.Remove(professor);
            //_context.SaveChanges();
        }
    }
}
