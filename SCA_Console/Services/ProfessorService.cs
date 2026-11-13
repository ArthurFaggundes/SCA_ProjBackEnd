using SCA_Console.Models;
using SCA_Console.Repository;

namespace SCA_Console.Services
{
    public class ProfessorService {

        //private readonly ProfessorRepository _professorRepository;

        //public ProfessorService(ProfessorRepository professorRepository) 
        //    { _professorRepository = professorRepository; }

        private ProfessorRepository _professorRepository = new ProfessorRepository();


        public void CriarProfessor(Professor prof) 
        {
            if (string.IsNullOrWhiteSpace(prof.nome)) 
            {
                throw new ArgumentException("Erro: nome não pode ser nulo ou em branco");
            }
            if (prof.nome.Length <= 2) 
            {
                throw new ArgumentException("Erro: nome tem que ter mais de dois caracteres");
            }
            _professorRepository.CriarProfessor(prof);
        }

        // Criar os métodos restantes do CRUD...
    }
}