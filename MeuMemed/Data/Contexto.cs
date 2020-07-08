using MeuMemed.Models;
using Microsoft.EntityFrameworkCore;
using MeuMemed.ViewModel.Paciente;
using MeuMemed.ViewModel.Medico;

namespace MeuMemed.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<MedicoCidade> MedicoCidades { get; set; }
        public DbSet<MedicoEspecialidade> MedicoEspecialidades { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PacienteViewModel> PacienteViewModel { get; set; }
        public DbSet<MedicoViewModel> MedicoViewModel { get; set; }
        public DbSet<PrescricaoMemed> PrescricoesMemed { get; set; }
    }
}
