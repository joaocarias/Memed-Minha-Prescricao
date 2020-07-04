using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuMemed.Models
{
    public class Paciente
    {
        public int PacienteId { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Cidade { get; private set; }
        public string Telefone { get; private set; }

        public Paciente(int pacienteId, string nome, string endereco, string cidade, string telefone)
        {
            PacienteId = pacienteId;
            Nome = nome;
            Endereco = endereco;
            Cidade = cidade;
            Telefone = telefone;
        }

        public Paciente()
        {
        }
    }
}
