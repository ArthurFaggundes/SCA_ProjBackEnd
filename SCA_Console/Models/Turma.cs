// using System.ComponentModel.DataAnnotations;

namespace SCA_Console.Models
{
    public class Turma
    {
        // [Key]
        public int idTurma { get; set; }
        public string local { get; set; }
        public bool aberta { get; set; } = false;

        public List<Aluno> alunos { get; set; } = new();
        public Disciplina? disciplina { get; set; }
        public Professor? professor { get; set; }

        

        public Turma(int idTurma, string local)
        {
            this.idTurma = idTurma;
            this.local = local;
        }

        public override string ToString() { 
            return $"ID: {idTurma}\n Local: {local}\n Aberta?: {aberta}\n Disciplina: {disciplina}\n Professor: {professor}";
        }

        public void Abrir() { aberta = true; }

        public void Fechar() { aberta = false; }

        //=============================================================================//

        //// Talvez colocar esses em Service!!!!!
        //public void InscreverAluno(Aluno alunoParaInscricao, Disciplina disciplina)
        //{ 
        //    alunos.Add(alunoParaInscricao); 
        //    alunoParaInscricao.IncrementarCredito(disciplina.numCreditos);
        //}

        public void DesignarProfessor(Professor professorDesignado)
        { professor = professorDesignado; } // por enquanto não é tão necessário

        public void DesignarDisciplina(Disciplina disciplinaDesignada)
        { disciplina = disciplinaDesignada; } // por enquanto não é tão necessário
    }
}