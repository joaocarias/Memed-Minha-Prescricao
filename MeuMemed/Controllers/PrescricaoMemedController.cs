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
