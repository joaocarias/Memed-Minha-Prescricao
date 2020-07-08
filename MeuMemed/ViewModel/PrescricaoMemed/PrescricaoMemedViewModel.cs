using System;
using System.ComponentModel.DataAnnotations;

namespace MeuMemed.ViewModel.PrescricaoMemed
{
    public class PrescricaoMemedViewModel
    {
        [Key]
        [Required]      
        public int Id { get; set; }

        [Required]       
        public int PrescricaoMemedId { get; set; }

        [Required]       
        public int MedicoId { get; set; }
               
        [Required]        
        public int PacienteId { get; set; }
       
        [Required]       
        public DateTime DataCadastro { get; set; }

        [Required]
        public string PrescricaoUUIDMemed { get; private set; }

        public PrescricaoMemedViewModel() { }

        public PrescricaoMemedViewModel(int prescricaoMemedId, int medicoId, int pacienteId, string prescricaoUUIDMemed, DateTime? dataCadastro = null)
        {
            PrescricaoMemedId = prescricaoMemedId;
            MedicoId = medicoId;
            PacienteId = pacienteId;
            DataCadastro = dataCadastro != null ? dataCadastro.GetValueOrDefault() : DateTime.Now;
            PrescricaoUUIDMemed = prescricaoUUIDMemed;
        }

        public PrescricaoMemedViewModel(int id, int prescricaoMemedId, int medicoId, int pacienteId, string prescricaoUUIDMemed, DateTime? dataCadastro = null)
        {
            Id = id;
            PrescricaoMemedId = prescricaoMemedId;
            MedicoId = medicoId;
            PacienteId = pacienteId;
            DataCadastro = dataCadastro != null ? dataCadastro.GetValueOrDefault() : DateTime.Now;
            PrescricaoUUIDMemed = prescricaoUUIDMemed;
        }
    }
}
