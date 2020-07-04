using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuMemed.Models
{
    public class Medico
    {
        public int MedicoId { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string CPF { get; private set; }
        public string CRM { get; private set; }
        public string UFCRM { get; private set; }
        public string Email { get; private set; }
        public string Sexo { get; private set; }
        public IList<int> Cidades { get; private set; }
        public IList<int> Especialidades { get; private set; }

        public Medico(int medicoId, string nome, string sobrenome)
        {
            MedicoId = medicoId;
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public Medico(int medicoId, string nome, string sobrenome, DateTime dataNascimento, string cPF, string cRM, string uFCRM, string email, string sexo) : this(medicoId, nome, sobrenome)
        {
            DataNascimento = dataNascimento;
            CPF = cPF;
            CRM = cRM;
            UFCRM = uFCRM;
            Email = email;
            Sexo = sexo;
        }

        private Medico() { }

        public void AdicionarCidade(int cidadeId)
        {
            Cidades.Add(cidadeId);
        }

        public void AdicionarEspecialidade(int especialidadeId)
        {
            Especialidades.Add(especialidadeId);
        }

        public string NomeCompleto {
            get {
                return Nome + " " + Sobrenome;
            }
        }

    }
}
