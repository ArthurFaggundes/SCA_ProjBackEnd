using SCA_Console.Models;
using SCA_Console.Services;

namespace SCA_Console.UI
{
    public class AlunoUI
    {
        private AlunoService _alunoService;
        public AlunoUI(AlunoService alunoService)
            { _alunoService = alunoService; }

        // -----------------------------------------------------------

        public void CriarNovoAluno()
        {
            Console.WriteLine("\n--- Criar novo aluno ---");
            try
            {
                int id = utilFuncs.EntrarId();
                string nome = utilFuncs.EntrarNome();

                Aluno tempAluno = new Aluno(id, nome);
                _alunoService.CriarAluno(tempAluno);

                Console.WriteLine("\n[Sucesso] Aluno cadastrado!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        public void MostrarTodosOsAlunos()
        {
            Console.WriteLine("\n--- Lista de alunos ---");

            List<Aluno> alunos = _alunoService.ListarAlunos();

            foreach (Aluno a in alunos)
            {
                Console.WriteLine($"- {a}");
            }
            Console.WriteLine("___________________________");
        }

        public void MostrarTurmasDoAluno()
        {
            Console.WriteLine("\n--- Buscar turmas do aluno ---");
            try
            {
                int id = utilFuncs.EntrarId();
                List<Turma> turmas = _alunoService.MostrarTurmasDoAluno(id);

                Console.WriteLine($"Turmas inscritas ({turmas.Count}):");

                foreach (Turma t in turmas)
                {
                    Console.WriteLine($"- {t}");
                }
                Console.WriteLine("___________________________");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}