using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuMemed.Models
{
    [Table("medico_cidade")]
    public class MedicoCidade
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; private set; }
        
        [Required]
        [Column("idcidade")]
        public int CidadeId { get; set; }
        [Required]
        [Column("idmedico")]
        public int MedicoId { get; set; }
               
        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }

        private MedicoCidade() {  }

        public MedicoCidade(int cidadeId, int medicoId)
        {
            CidadeId = cidadeId;
            MedicoId = medicoId;
        }
    }
}
