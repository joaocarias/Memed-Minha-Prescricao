using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MeuMemed.Data;
using MeuMemed.Data.IRepositorios;
using MeuMemed.Models;
using MeuMemed.ViewModel.Paciente;
using Microsoft.AspNetCore.Mvc;

namespace MeuMemed.Controllers
{
    public class PacienteController : Controller
    {
        private readonly Contexto _contexto;
        private readonly IRepositorioPaciente _repositorioPaciente;       
        private readonly IMapper _mapper;

        public PacienteController(Contexto contexto, IMapper mapper, IRepositorioPaciente repositorioPaciente)
        {
            _contexto = contexto;
            _mapper = mapper;
            _repositorioPaciente = repositorioPaciente;
        }

        public IActionResult Index()
        {
            var pacientes = _contexto.Pacientes.ToList();
            var model = _mapper.Map<List<PacienteViewModel>>(pacientes);

            return View(model);
        }

        public IActionResult Novo() 
        { 
            var model = new PacienteViewModel();
            return View(model);   
        }
        
        [HttpPost]
        public IActionResult Novo(PacienteViewModel pacienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(pacienteViewModel);
            }

            var paciente = _mapper.Map<Paciente>(pacienteViewModel);
            _contexto.Pacientes.Add(paciente);
            _contexto.SaveChanges();

            return RedirectToAction(nameof(Detalhes), paciente.PacienteId);
        }

        public IActionResult Detalhes(int id)
        {   
            var paciente = _repositorioPaciente.Obter(id);
            var model = _mapper.Map<PacienteViewModel>(paciente);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var paciente = _repositorioPaciente.Obter(id);
            var model = _mapper.Map<PacienteViewModel>(paciente);
            return View(model);
        }

        [HttpPost]
        public IActionResult Deletar(int PacienteId)
        {
            var paciente = _repositorioPaciente.Obter(PacienteId);
            _contexto.Pacientes.Remove(paciente);
            _contexto.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
