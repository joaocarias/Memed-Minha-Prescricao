using MeuMemed.Data.IRepositorios;
using MeuMemed.Models;
using System.Collections.Generic;
using System.Linq;

namespace MeuMemed.Data.Repositorios
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        private IList<Paciente> _pacientes = new List<Paciente>()
        {
            new Paciente(602123, "JOÃO CARIAS DE FRANÇA", "RUA VALMIR TARGINO, 356 - CENTRO", "MESSIAS TARGINO-RN", "84996668298"),
            new Paciente(602135, "ANA CRISTINA DE ALMEIDA ANDRADE", "RUA VALMIR TARGINO, 509 - CENTRO", "MESSIAS TARGINO-RN", "84997074698"),
            new Paciente(602169, "GUILHERME CARIAS DE FRANÇA", "AV. MARECHAL FLORIANO PEIXOTO, 502 - TIROL", "NATAL-RN", "84998693002"),
            new Paciente(602179, "MARIA MADALENA CARIAS JALES DE FRANÇA", "SÍTIO BOM FUTURO", "CAMPO GRANDE-RN", "84992096123"),
            new Paciente(602200, "JUVENAL GUILHERME DE FRANÇA", "RUA JOÃO CARIAS DE OLIVEIRA, 1023 - BOA VISTA", "MOSSORÓ-RN", "84996010368"),           
        };

        public List<Paciente> ObterTodos()
        {
            return _pacientes.ToList();
        }

        public Paciente Obter(int id)
        {
            return _pacientes.Where(x => x.PacienteId == id).FirstOrDefault();
        }
    }
}
