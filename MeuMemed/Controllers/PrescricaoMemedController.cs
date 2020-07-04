using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuMemed.Data.IRepositorios;
using MeuMemed.ViewModel.PrescricaoMemed;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MeuMemed.Controllers
{
    public class PrescricaoMemedController : Controller
    {
        private readonly IRepositorioMedico _repositorioMedico;
        private readonly IRepositorioPaciente _repositorioPaciente;

        public PrescricaoMemedController(IRepositorioMedico repositorioMedico, IRepositorioPaciente repositorioPaciente)
        {
            _repositorioMedico = repositorioMedico;
            _repositorioPaciente = repositorioPaciente;
        }

        public IActionResult Index(FiltroPrescricaoMemedViewModel filtro = null)
        {
            var model = new PrescricaoMemedViewModel(filtro);
            if (filtro != null && filtro.MedicoId > 0)
            {
                filtro.Medico = _repositorioMedico.Obter(filtro.MedicoId.GetValueOrDefault());
                filtro.Medico.DefinirToten("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.WzM0Mzg0LCJlYTE4OTU2MzRiNjEwOTdmOGMwM2U5M2QzNWMwOTZmNCIsIjIwMjAtMDctMDIiLCJzaW5hcHNlLnByZXNjcmljYW8iLCJwYXJ0bmVyLjMuMjk3ODYiXQ.yDSRFIm72-EkI12oSMBUqSHFGq6msl7xnT4Ci9d9W40");
            }

            if (filtro != null && filtro.PacienteId > 0)
            {
                filtro.Paciente = _repositorioPaciente.Obter(filtro.PacienteId.GetValueOrDefault());
            }

            GerarViewBags();
            return View(model);
        }


        #region viewbag
        
        private void GerarViewBags()
        {
            var medicos = _repositorioMedico.ObterTodos()
                            .Select(p => new { Id = p.MedicoId, Nome = p.Nome + " " + p.Sobrenome }).ToList();

            var pacientes = _repositorioPaciente.ObterTodos()
                            .Select(p => new { Id = p.PacienteId, p.Nome }).ToList();

            ViewBag.Medicos = new SelectList(medicos, "Id", "Nome");
            ViewBag.Pacientes = new SelectList(pacientes, "Id", "Nome");
        }

        #endregion
    }
}
