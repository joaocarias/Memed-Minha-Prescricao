using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuMemed.Models
{
    [Table("prescricoes_memed")]
    public class PrescricaoMemed
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; private set; }

        [Required]
        [Column("idprescricao_memed")]
        public int PrescricaoMemedId { get; private set; }

        [Required]
        [Column("idmedico")]
        public int MedicoId { get; private set; }

        [ForeignKey("MedicoId")]
        public Medico Medico { get; private set; }

        [Required]
        [Column("idpaciente")]
        public int PacienteId { get; private set; }
        
        [ForeignKey("PacienteId")]
        public Paciente Paciente { get; private set; }

        [Required]
        [Column("dt_cadastro")]
        public DateTime DataCadastro { get; private set; }

        [Required]
        [Column("prescricao_uuid_memed")]
        public string PrescricaoUUIDMemed { get; private set; }

        private PrescricaoMemed() { }

        public PrescricaoMemed(int prescricaoMemedId, int medicoId, int pacienteId, string prescricaoUUIDMemed, DateTime? dataCadastro = null)
        {
            PrescricaoMemedId = prescricaoMemedId;
            MedicoId = medicoId;
            PacienteId = pacienteId;
            DataCadastro = dataCadastro != null ? dataCadastro.GetValueOrDefault() : DateTime.Now;
            PrescricaoUUIDMemed = prescricaoUUIDMemed;
        }

        public PrescricaoMemed( int medicoId, int pacienteId, string prescricaoUUIDMemed, DateTime? dataCadastro = null)
        {            
            MedicoId = medicoId;
            PacienteId = pacienteId;
            DataCadastro = dataCadastro != null ? dataCadastro.GetValueOrDefault() : DateTime.Now;
            PrescricaoUUIDMemed = prescricaoUUIDMemed;
        }
    }
}
