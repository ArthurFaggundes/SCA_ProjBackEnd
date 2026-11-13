using SCA_Console.Models;
using SCA_Console.Services;

namespace SCA_Console.UI
{
    public class ProfessorUI
    {
        private ProfessorService _professorService;
        public ProfessorUI(ProfessorService professorService)
        { _professorService = professorService; }
    }
}