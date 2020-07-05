using MeuMemed.Models;

namespace MeuMemed.ViewModel.PrescricaoMemed
{
    public class FiltroPrescricaoMemedViewModel
    {
        public int? MedicoId { get; set; }
        public Models.Medico Medico { get; set; }
        public int? PacienteId { get; set; }
        public Models.Paciente Paciente { get; set; }

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
