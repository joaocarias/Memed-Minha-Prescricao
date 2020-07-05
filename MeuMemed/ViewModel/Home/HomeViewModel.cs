using MeuMemed.Models;
using System.Collections.Generic;

namespace MeuMemed.ViewModel.Home
{
    public class HomeViewModel
    {
        public IList<Models.Medico> Medicos { get; set; }
        public IList<Models.Paciente> Pacientes { get; set; }

        public HomeViewModel()
        {
            Medicos = new List<Models.Medico>();
            Pacientes = new List<Models.Paciente>();
        }

        public HomeViewModel(List<Models.Medico> medicos, List<Models.Paciente> pacientes)
        {
            Medicos = medicos;
            Pacientes = pacientes;
        }
    }
}
