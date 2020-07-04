namespace MeuMemed.ViewModel.PrescricaoMemed
{
    public class PrescricaoMemedViewModel
    {
        public FiltroPrescricaoMemedViewModel Filtro { get; set; }
        
        public PrescricaoMemedViewModel(FiltroPrescricaoMemedViewModel filtro)
        {
            Filtro = filtro;
        }

        public PrescricaoMemedViewModel()
        {
        }

        public bool PermiteCriar()
        {
            if(Filtro != null && Filtro.PacienteId > 0 && Filtro.MedicoId > 0)
            {
                return true;
            }

            return false;
        }
    }
}
