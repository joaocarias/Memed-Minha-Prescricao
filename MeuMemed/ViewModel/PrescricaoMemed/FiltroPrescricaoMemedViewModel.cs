using MeuMemed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuMemed.ViewModel.PrescricaoMemed
{
    public class FiltroPrescricaoMemedViewModel
    {
        public int? MedicoId { get; set; }
        public Medico Medico { get; set; }
        public int? PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public FiltroPrescricaoMemedViewModel(int medicoId, int pacienteId)
        {
            MedicoId = medicoId;
            PacienteId = pacienteId;
        }

        public FiltroPrescricaoMemedViewModel()
        {
        }
    }
}
