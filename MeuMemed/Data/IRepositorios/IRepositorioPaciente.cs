using MeuMemed.Models;
using System.Collections.Generic;

namespace MeuMemed.Data.IRepositorios
{
    public interface IRepositorioPaciente
    {
        List<Paciente> ObterTodos();
        Paciente Obter(int id);
    }
}
