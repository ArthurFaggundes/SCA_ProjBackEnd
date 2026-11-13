using SCA_Console.Models;
using SCA_Console.Repository;

namespace SCA_Console.Services
{
    public class TurmaService
    {
        private readonly TurmaRepository _turmaRepository;
        private readonly AlunoRepository _alunoRepository;
        public TurmaService(TurmaRepository turmaRepository, AlunoRepository alunoRepository)
        {
            _turmaRepository = turmaRepository;
            _alunoRepository = alunoRepository;
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void CriarTurma(Turma turma)
        {
            if (turma == null)
            {
                throw new ArgumentException("[Erro] turma não pode ser nula.");
            }
            if (string.IsNullOrWhiteSpace(turma.local) || turma.local.Length <= 2)
            {
                throw new ArgumentException("[Erro] turma deve conter um local válido.");
            }
            if (_turmaRepository.BuscarTurma(turma.idTurma) != null)
            {
                throw new ArgumentException("[Erro] Já existe uma turma com esse ID.");
            }
            if (turma.idTurma <= 0)
            {
                throw new ArgumentException("[Erro] O ID da turma deve ser maior que 0.");
            }

            turma.Abrir(); 
            //?? não sei se é para estar aqui
            //?? "O atributo aberta é inicializado como falso e alterado para verdadeiro quando a turma for aberta com sucesso"
            //?? ou seja, quando ela abre, ela abre :) ????

            _turmaRepository.CriarTurma(turma);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public List<Turma> ListarTodasAsTurmas()
        {
            return _turmaRepository.ListarTurmas();
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void ExcluirTurma(int idTurma)
        {
            Turma turma = _turmaRepository.BuscarTurma(idTurma);

            if (turma == null)
            {
                throw new KeyNotFoundException("[Erro] Turma não encontrada.");
            }
            if (turma.aberta)
            {
                throw new InvalidOperationException(
                    "[Erro] Não é permitido excluir uma turma aberta.");
            }

            // Remove a referência da turma dos alunos matriculados.
            foreach (Aluno a in turma.alunos)
            {
                a.turmas.Remove(turma);
            }

            _turmaRepository.ExcluirTurma(idTurma);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void MatricularAluno(int idAluno, int idTurma)
        {
            //?? não entedi o "método matricular deve permitir no máximo cinco alunos por turma"
            //?? seria para criar um Loop onde permite cadastrar 5 alunos ao mesmo tempo?

            Aluno aluno = _alunoRepository.BuscarAluno(idAluno);
            Turma turma = _turmaRepository.BuscarTurma(idTurma);

            if (aluno == null)
            {
                throw new KeyNotFoundException("[Erro] Aluno não encontrado.");
            }
            if (turma == null)
            {
                throw new KeyNotFoundException("[Erro] Turma não encontrada.");
            }
            if (turma.alunos.Any(a => a.idAluno == idAluno))
            {
                throw new ArgumentException("[Erro] Aluno já está matriculado nesta turma.");
            }

            // Atualiza os dos dois relacionamentos, é tipo uma tabela n:n
            turma.alunos.Add(aluno);
            aluno.turmas.Add(turma);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void AbrirTurma(int idTurma)
        {
            //?? "método abrir deve permitir no mínimo dois alunos por turma"
            //?? então para abrir uma turma precisa de alunos?

            Turma turma = _turmaRepository.BuscarTurma(idTurma);

            if (turma == null)
            {
                throw new KeyNotFoundException("[Erro] Turma não encontrada.");
            }
            if (turma.aberta)
            {
                throw new InvalidOperationException("[Erro] Turma já está aberta.");
            }

            turma.Abrir();
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public List<Aluno> ExibirPauta(int idTurma) // Exibir alunos
        {
            Turma turma = _turmaRepository.BuscarTurma(idTurma);

            if (turma != null)
            {
                return turma.alunos;
            }
            throw new KeyNotFoundException("[Erro] Turma não foi encontrada.");
        }
    }
}
