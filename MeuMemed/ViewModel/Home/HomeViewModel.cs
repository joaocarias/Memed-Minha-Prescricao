using MeuMemed.Models;
using System.Collections.Generic;

namespace MeuMemed.ViewModel.Home
{
    public class HomeViewModel
    {
        public IList<Medico> Medicos { get; set; }
        public IList<Paciente> Pacientes { get; set; }

        public HomeViewModel()
        {
            Medicos = new List<Medico>();
            Pacientes = new List<Paciente>();
        }

        public HomeViewModel(List<Medico> medicos, List<Paciente> pacientes)
        {
            Medicos = medicos;
            Pacientes = pacientes;
        }
    }
}
