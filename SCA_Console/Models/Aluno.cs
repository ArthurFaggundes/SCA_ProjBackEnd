// using System.ComponentModel.DataAnnotations;

namespace SCA_Console.Models
{
    public class Aluno
    {
        // [Key]
        public int idAluno { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; } = false;

        public List<Turma> turmas { get; set; } = new();
        public int numCredAtuais { get; set; } = 0;

        public Aluno(int idAluno, string nome)
        {
            this.idAluno = idAluno;
            this.nome = nome;
        }

        public override string ToString() { 
            return $"ID: {idAluno}\n Nome: {nome}\n Ativo?: {ativo}\n";
        }

        public void Ativar() { ativo = true; }

        public void Desativar() { ativo = false; }

        //=============================================================================//

        public void IncrementarCredito(int numCredito) // Talvez colocar isso em Service!!!!!
        {
            this.numCredAtuais += numCredito;
        }
        //public static List<Turma> RetornaTurmas(int id, string nome)
        //{
        //    Aluno aluno = new(id, nome);
        //    return aluno.turmas;
        //}
    }
}
