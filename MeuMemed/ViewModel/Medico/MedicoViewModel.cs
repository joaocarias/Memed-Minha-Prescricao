using MeuMemed.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeuMemed.ViewModel.Medico
{
    public class MedicoViewModel
    {
        [Key]
        [Required]
        public int MedicoId { get; set; }

        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string Sobrenome { get; set; }

        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string CRM { get; set; }
        public string UFCRM { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }

        public string Toten { get; set; }
        public string MemedId { get; set; }

        public IList<MedicoCidade> Cidades { get; set; }
        public IList<MedicoEspecialidade> Especialidades { get; set; }

        public MedicoViewModel(int medicoId, string nome, string sobrenome)
        {
            MedicoId = medicoId;
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public MedicoViewModel(int medicoId, string nome, string sobrenome, DateTime dataNascimento, string cPF, string cRM, string uFCRM, string email, string sexo) : this(medicoId, nome, sobrenome)
        {
            DataNascimento = dataNascimento;
            CPF = cPF;
            CRM = cRM;
            UFCRM = uFCRM;
            Email = email;
            Sexo = sexo;
        }

        public MedicoViewModel() { }

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
    }
}
