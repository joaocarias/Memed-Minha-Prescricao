using AutoMapper;
using MeuMemed.Models;
using MeuMemed.ViewModel.Medico;
using MeuMemed.ViewModel.Paciente;

namespace MeuMemed.Helpers
{
    public class MeuAutoMapper : Profile
    {
        public MeuAutoMapper()
        {
            CreateMap<Paciente, PacienteViewModel>().ReverseMap();
            CreateMap<Medico, MedicoViewModel>().ReverseMap();
        }
    }
}
