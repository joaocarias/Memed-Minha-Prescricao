using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuMemed.Data;
using MeuMemed.Data.IRepositorios;
using MeuMemed.Models;
using MeuMemed.ViewModel.PrescricaoMemed;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MeuMemed.Controllers
{
    public class PrescricaoMemedController : Controller
    {
        private readonly IRepositorioMedico _repositorioMedico;
        private readonly IRepositorioPaciente _repositorioPaciente;
        private readonly Contexto _contexto;

        public PrescricaoMemedController(Contexto contexto, IRepositorioMedico repositorioMedico, IRepositorioPaciente repositorioPaciente)
        {
            _repositorioMedico = repositorioMedico;
            _repositorioPaciente = repositorioPaciente;
            _contexto = contexto;
        }

        public IActionResult Index(FiltroPrescricaoMemedViewModel filtro = null)
        {
            var model = new HomePrescricaoMemedViewModel(filtro);
            if (filtro != null && filtro.MedicoId > 0)
            {
                filtro.Medico = _repositorioMedico.Obter(filtro.MedicoId.GetValueOrDefault());               
            }

            if (filtro != null && filtro.PacienteId > 0)
            {
                filtro.Paciente = _repositorioPaciente.Obter(filtro.PacienteId.GetValueOrDefault());
            }

            GerarViewBags();
            return View(model);
        }

        public IActionResult Salvar(int idPrescricao, DateTime dataCriacao, string prescricaoUuid, int idPaciente, string medicoCRM)
        {
            var medico = _repositorioMedico.ObterPorCRM(medicoCRM);
            if (medico != null)
            {
                var prescricao = new PrescricaoMemed(idPrescricao, medico.MedicoId, idPaciente, prescricaoUuid, dataCriacao);
                _contexto.PrescricoesMemed.Add(prescricao);
                _contexto.SaveChanges();

                return Ok("Prescricao Salva!");
            }
            else
            {
                return BadRequest("Não foi possível identificar o médico");
            }          
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
