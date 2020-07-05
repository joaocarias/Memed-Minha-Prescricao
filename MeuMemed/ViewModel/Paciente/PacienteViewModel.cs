using System.ComponentModel.DataAnnotations;

namespace MeuMemed.ViewModel.Paciente
{
    public class PacienteViewModel
    {
        [Key]
        [Required]
        public int PacienteId { get; set; }
        [Required]
        public string Nome { get; set; }

        public string Endereco { get; set; }
        public string Cidade { get; set; }

        [Required]
        public string Telefone { get; set; }
        public int? Peso { get; set; }
        public double? Altura { get; set; }
        public string NomeMae { get; set; }
        public bool? DificuldadeLocomocao { get; set; }

        public PacienteViewModel(int pacienteId, string nome, string endereco, string cidade, string telefone)
        {
            PacienteId = pacienteId;
            Nome = nome;
            Endereco = endereco;
            Cidade = cidade;
            Telefone = telefone;
        }

        public PacienteViewModel(string nome, string endereco, string cidade, string telefone)
        {
            Nome = nome;
            Endereco = endereco;
            Cidade = cidade;
            Telefone = telefone;
        }

        public PacienteViewModel(string nome, string endereco, string cidade, string telefone, int? peso, float? altura, string nomeMae, bool? dificuldadeLocomocao)
        {
            Nome = nome;
            Endereco = endereco;
            Cidade = cidade;
            Telefone = telefone;
            Peso = peso;
            Altura = altura;
            NomeMae = nomeMae;
            DificuldadeLocomocao = dificuldadeLocomocao;
        }

        public PacienteViewModel(int pacienteId, string nome, string endereco, string cidade, string telefone, int? peso, float? altura, string nomeMae, bool? dificuldadeLocomocao) : this(pacienteId, nome, endereco, cidade, telefone)
        {
            Peso = peso;
            Altura = altura;
            NomeMae = nomeMae;
            DificuldadeLocomocao = dificuldadeLocomocao;
        }

        public PacienteViewModel() { }
    }
}
