using SCA_Console.Models;

namespace SCA_Console.Repository
{
    public class TurmaRepository
    {
        public readonly List<Turma> listaTurmas = new List<Turma>();

        public void CriarTurma(Turma turma)
        {
            listaTurmas.Add(turma);
        }

        public void ExcluirTurma(int id)
        {
            Turma turma = BuscarTurma(id);

            if (turma != null)
            {
                listaTurmas.Remove(turma);
            }
        }

        public List<Turma> ListarTurmas()
        {
            return listaTurmas;
        }

        public Turma BuscarTurma(int id)
        {
            return listaTurmas.FirstOrDefault(t => t.idTurma == id)!;
        }
    }
}
