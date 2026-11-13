using SCA_Console.Repository;
using SCA_Console.Services;
using SCA_Console.UI;

public class Program
{
    static void Main(string[] args)
    {
        AlunoRepository alunoRepository = new();
        AlunoService alunoService = new(alunoRepository);
        AlunoUI alunoUI = new(alunoService);

        TurmaRepository turmaRepository = new();
        TurmaService turmaService = new(turmaRepository, alunoRepository);
        TurmaUI turmaUI = new(turmaService);

        //ProfessorRepository professorRepository = new();
        //ProfessorService professorService = new(professorRepository);
        //ProfessorUI professorUI = new(professorService);

        while (true)
        {
            Console.WriteLine("\n--- Bem-vindo(a) o que deseja fazer? ---");

            Console.WriteLine("1. Criar novo Aluno");
            Console.WriteLine("2. Mostrar todos os alunos");
            Console.WriteLine("3. Mostrar todas as turmas de um aluno");
            Console.WriteLine();
            Console.WriteLine("4. Criar nova Turma");
            Console.WriteLine("5. Mostrar todas as turmas");
            Console.WriteLine("6. Mostrar todos os alunos de uma turma");
            Console.WriteLine("7. Excluir turma");
            Console.WriteLine("8. Abrir turma existente");
            Console.WriteLine("9. Matricular aluno a uma turma");
            Console.WriteLine();
            Console.WriteLine("0. Sair");
            Console.Write("[ESCOLHA]: ");
            string? escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    alunoUI.CriarNovoAluno();
                    break;
                case "2":
                    alunoUI.MostrarTodosOsAlunos();
                    break;
                case "3":
                    alunoUI.MostrarTurmasDoAluno();
                    break;
                case "4":
                    turmaUI.CriarNovaTurma();
                    break;
                case "5":
                    turmaUI.MostrarTodasAsTurmas();
                    break;
                case "6":
                    turmaUI.MostrarPauta();
                    break;
                case "7":
                    turmaUI.ExcluirTurma();
                    break;
                case "8":
                    turmaUI.AbrirTurma();
                    break;
                case "9":
                    turmaUI.MatricularAluno();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}