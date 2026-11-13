using SCA_Console.Models;
using SCA_Console.Services;

namespace SCA_Console.UI
{
    public class TurmaUI
    {
        private TurmaService _turmaService;
        public TurmaUI(TurmaService turmaService)
            { _turmaService = turmaService; }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void CriarNovaTurma()
        {
            Console.WriteLine("\n--- Criar nova turma ---");
            try
            {
                int id = utilFuncs.EntrarId();

                Console.Write("Insira o nome do local: ");
                string local = Console.ReadLine() ?? ""; // lança um erro caso nã0 digite nada [service]

                Turma tempTurma = new Turma(id, local);
                _turmaService.CriarTurma(tempTurma);

                Console.WriteLine("\n[Sucesso] Turma cadastrada!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void ExcluirTurma()
        {
            Console.WriteLine("\n--- Excluir turma ---");

            try
            {
                int id = utilFuncs.EntrarId(); // !!!!!!!!!! adapatar

                _turmaService.ExcluirTurma(id);

                Console.WriteLine($"\n[Sucesso] Turma {id} excluída!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        
        public void AbrirTurma()
        {
            Console.WriteLine("\n--- Abrir turma ---");

            try
            {
                int id = utilFuncs.EntrarId(); // !!!!!!!!!! adapatar

                _turmaService.AbrirTurma(id);

                Console.WriteLine("\n[Sucesso] Turma aberta!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void MostrarTodasAsTurmas()
        {
            Console.WriteLine("\n--- Buscar todas as turmas ---");

            List<Turma> turmas = _turmaService.ListarTodasAsTurmas();

            if (turmas.Count == 0)
            {
                Console.WriteLine("Nenhuma turma cadastrada.");
                return;
            }

            foreach (Turma t in turmas)
            {
                Console.WriteLine($"- {t}");
            }
            Console.WriteLine("___________________________");
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void MatricularAluno()
        {
            Console.WriteLine("\n--- Matricular aluno ---");

            try
            {
                Console.Write("Insira o ID do aluno: ");
                int idAluno = utilFuncs.EntrarId(); // !!!!!!!!!! adapatar

                Console.Write("Insira o ID da turma: ");
                int idTurma = utilFuncs.EntrarId(); // !!!!!!!!!! adapatar

                _turmaService.MatricularAluno(idAluno, idTurma);

                Console.WriteLine($"\n[Sucesso] Aluno {idAluno} matriculado na turma {idTurma}!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void MostrarPauta()
        {
            Console.WriteLine("\n--- Pauta da turma ---");

            try
            {
                int id = utilFuncs.EntrarId();

                List<Aluno> alunos = _turmaService.ExibirPauta(id);

                Console.WriteLine($"Alunos matriculados ({alunos.Count}):");

                foreach (Aluno a in alunos)
                {
                    Console.WriteLine($"- {a}");
                }
                Console.WriteLine("___________________________");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}