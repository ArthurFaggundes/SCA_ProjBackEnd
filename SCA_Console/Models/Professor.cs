using System.ComponentModel.DataAnnotations;

namespace SCA_Console.Models
{
    public class Professor
    {
        [Key]
        public int idProfessor { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; } = false;



        public Professor(int idProfessor, string nome)
        {
            this.idProfessor = idProfessor;
            this.nome = nome;
        }

        public override string ToString() { 
            return $"ID: {idProfessor}\n Nome: {nome}\n Ativo?: {ativo}\n";
        }

        public void Ativar() { ativo = true; }

        public void Desativar() { ativo = false; }

        //=============================================================================//
    }
}
