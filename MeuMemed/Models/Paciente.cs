using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuMemed.Models
{
    [Table("pacientes")]
    public class Paciente
    {
        [Key]
        [Required]
        [Column("id")]
        public int PacienteId { get; private set; }
        [Required]
        [Column("nome")]
        public string Nome { get; private set; }

        [Column("endereco")]
        public string Endereco { get; private set; }
        [Column("cidade")]
        public string Cidade { get; private set; }

        [Required]
        [Column("telefone")]
        public string Telefone { get; private set; }
        [Column("peso")]
        public int? Peso { get; private set; }
        [Column("altura")]
        public float? Altura { get; private set; }
        [Column("nome_mae")]
        public string NomeMae { get; private set; }
        [Column("dificuldade_locomocao")]
        public bool? DificuldadeLocomocao { get; private set; }

        public Paciente(int pacienteId, string nome, string endereco, string cidade, string telefone)
        {
            PacienteId = pacienteId;
            Nome = nome;
            Endereco = endereco;
            Cidade = cidade;
            Telefone = telefone;
        }

        private Paciente() { }
    }
}
