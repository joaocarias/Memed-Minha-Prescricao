using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuMemed.Models
{
    [Table("medico_especialidade")]
    public class MedicoEspecialidade
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; private set; }

        [Required]
        [Column("idespecialidade")]
        public int EspecialidadeId { get; set; }
        [Required]
        [Column("idmedico")]
        public int MedicoId { get; set; }

        //NAV
        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }

        private MedicoEspecialidade() { }

        public MedicoEspecialidade(int especialidadeId, int medicoId)
        {
            EspecialidadeId = especialidadeId;
            MedicoId = medicoId;
        }
    }
}
