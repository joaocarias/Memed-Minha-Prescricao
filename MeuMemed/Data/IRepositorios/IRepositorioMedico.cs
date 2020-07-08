using MeuMemed.Models;
using System.Collections.Generic;

namespace MeuMemed.Data.IRepositorios
{
    public interface IRepositorioMedico
    {
        Medico Obter(int id);
        List<Medico> ObterTodos();
        Medico ObterPorCRM(string crm);
    }
}
