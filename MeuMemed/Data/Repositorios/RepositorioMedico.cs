using MeuMemed.Data.IRepositorios;
using MeuMemed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuMemed.Data.Repositorios
{
    public class RepositorioMedico : IRepositorioMedico
    {
        private IList<Medico> _medicos = new List<Medico>()
        {
            new Medico(201001, "ANTONIO", "CARDOZO JALES"),
            new Medico(201023, "FRANCISCO", "GERFESSO DE ALMEIDA ANDRADE"),
            new Medico(201601, "JOSÉ", "MARIA BEZERRA DE MEDEIROS"),
        };

        public Medico Obter(int id)
        {
           return _medicos.Where(x => x.MedicoId == id).FirstOrDefault();
        }

        public List<Medico> ObterTodos()
        {
            return _medicos.ToList();
        }
    }
}
