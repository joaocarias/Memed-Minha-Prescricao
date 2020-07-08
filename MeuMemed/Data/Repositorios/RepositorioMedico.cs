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
        private readonly Contexto _contexto;

        public RepositorioMedico(Contexto contexto)
        {
            _contexto = contexto;
        }

        public Medico Obter(int id)
        {
            return _contexto.Medicos.Where(x => x.MedicoId == id).FirstOrDefault();
        }

        public Medico ObterPorCRM(string crm)
        {
            return _contexto.Medicos.Where(x => x.CRM.Equals(crm)).FirstOrDefault();
        }

        public List<Medico> ObterTodos()
        {
            return _contexto.Medicos.ToList();
        }
    }
}
