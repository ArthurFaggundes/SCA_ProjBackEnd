using System.ComponentModel.DataAnnotations;

namespace SCA_Console.Models
{ 
	public class Disciplina
	{
        [Key]
		public int idDisciplina { get; set; }
        public string nome { get; set; }
        public string cargaHoraria { get; set; }
		public int numCreditos { get; set; }



        public Disciplina(int idDisciplina, string nome, string cargaHoraria, int numCreditos)
        {
            this.idDisciplina = idDisciplina;
            this.nome = nome;
			this.cargaHoraria = cargaHoraria;
			this.numCreditos = numCreditos;
        }

        public override string ToString() { 
            return $"ID: {idDisciplina}\n Nome: {nome}\n Carga Horária: {cargaHoraria}\n Núm. Créditos: {numCreditos}\n";
        }

        //=============================================================================//
    }
}

