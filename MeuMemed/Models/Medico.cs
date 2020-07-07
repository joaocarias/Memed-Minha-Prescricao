using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuMemed.Models
{
    [Table("medicos")]
    public class Medico
    {
        [Key]
        [Required]
        [Column("id")]
        public int MedicoId { get; private set; }
        [Required]
        [Column("nome")]
        public string Nome { get; private set; }
        [Required]
        [Column("sobrenome")]
        public string Sobrenome { get; private set; }

        [Column("data_nascimento")]
        public DateTime DataNascimento { get; private set; }
        [Column("cpf")]
        public string CPF { get; private set; }
        [Column("crm")]
        public string CRM { get; private set; }
        [Column("uf")]
        public string UFCRM { get; private set; }
        [Column("email")]
        public string Email { get; private set; }
        [Column("sexo")]
        public string Sexo { get; private set; }

        [Column("toten")]
        public string Toten { get; private set; }
        [Column("idmemed")]
        public string MemedId { get; private set; }

        public IList<MedicoCidade> Cidades { get; private set; }
        public IList<MedicoEspecialidade> Especialidades { get; private set; }

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

        public void AdicionarCidade(MedicoCidade valor)
        {
            Cidades.Add(valor);
        }

        public void AdicionarEspecialidade(MedicoEspecialidade valor)
        {
            Especialidades.Add(valor);
        }

        public string NomeCompleto {
            get {
                return Nome + " " + Sobrenome;
            }
        }

        public void DefinirToten(string toten)
        {
            Toten = toten;
        }

        public void DefinirEmail(string email)
        {
            Email = email;
        }

        public string ExternoId {
            get {
                return "liga-m" + MedicoId;
            }
        }

        public void DefinirMemedId(string memedId) {
            MemedId = memedId;
        }
    }
}
