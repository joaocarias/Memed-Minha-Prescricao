using MeuMemed.Data.IRepositorios;
using MeuMemed.Models;
using System.Collections.Generic;
using System.Linq;

namespace MeuMemed.Data.Repositorios
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        private readonly Contexto _contexto;

        public RepositorioPaciente(Contexto contexto)
        {
            _contexto = contexto;
        }

        public List<Paciente> ObterTodos()
        {
            return _contexto.Pacientes.ToList();
        }

        public Paciente Obter(int id)
        {
            return _contexto.Pacientes.Where(x => x.PacienteId == id).FirstOrDefault();
        }
    }
}
