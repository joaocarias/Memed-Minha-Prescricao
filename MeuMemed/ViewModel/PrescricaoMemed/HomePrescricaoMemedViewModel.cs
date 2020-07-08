namespace MeuMemed.ViewModel.PrescricaoMemed
{
    public class HomePrescricaoMemedViewModel
    {
        public FiltroPrescricaoMemedViewModel Filtro { get; set; }
        
        public HomePrescricaoMemedViewModel(FiltroPrescricaoMemedViewModel filtro)
        {
            Filtro = filtro;
        }

        public HomePrescricaoMemedViewModel()
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
