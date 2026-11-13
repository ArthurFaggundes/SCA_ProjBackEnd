using SCA_Console.Models;
using SCA_Console.Repository;

namespace SCA_Console.Services
{
    public class AlunoService
    {
        private AlunoRepository _alunoRepository;

        public AlunoService(AlunoRepository alunoRepository)
            { _alunoRepository = alunoRepository; } // faz com que todo o Cód. compartilhe a lista



        public void CriarAluno(Aluno aluno)
        {
            if (string.IsNullOrWhiteSpace(aluno.nome))
            {
                throw new ArgumentException("Erro: nome não pode ser nulo ou em branco");
            }
            if (aluno.nome.Length <= 2)
            {
                throw new ArgumentException("Erro: nome tem que ter mais de dois caracteres");
            }
            if (_alunoRepository.BuscarAluno(aluno.idAluno) != null)
            {
                throw new ArgumentException("Erro: Já existe um aluno com esse ID.");
            }

            _alunoRepository.CriarAluno(aluno);
        }

        public List<Aluno> ListarAlunos()
        {
            return _alunoRepository.ListarAlunos();
            // da pra encaixar verificiações e precisar
        }

        public List<Turma> MostrarTurmasDoAluno(int id)
        {
            Aluno aluno = _alunoRepository.BuscarAluno(id);

            if (aluno != null)
            {
                return aluno.turmas;
            }

            throw new KeyNotFoundException("Aluno não encontrado.");
        }
    }
}
