using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeuMemed.Data;
using MeuMemed.Data.IRepositorios;
using MeuMemed.Models;
using MeuMemed.ViewModel.Medico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuMemed.Controllers
{
    public class MedicoController : Controller
    {

        private readonly Contexto _contexto;
        private readonly IRepositorioMedico _repositorioMedico;
        private readonly IMapper _mapper;

        public MedicoController(Contexto contexto, IMapper mapper, IRepositorioMedico repositorioMedico)
        {
            _contexto = contexto;
            _mapper = mapper;
            _repositorioMedico = repositorioMedico;
        }
        public ActionResult Index()
        {
            var medicos = _repositorioMedico.ObterTodos();
            var model = _mapper.Map<List<MedicoViewModel>>(medicos);
            return View(model);
        }
              
        public ActionResult Detalhes(int id)
        {
            var medico = _repositorioMedico.Obter(id);
            var model = _mapper.Map<MedicoViewModel>(medico);
            return View(model);
        }
               
        public ActionResult Novo()
        {
            var model = new MedicoViewModel();
            return View(model);
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]      
        public IActionResult Novo(MedicoViewModel medicoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(medicoViewModel);
            }

            var medico = _mapper.Map<Medico>(medicoViewModel);
            _contexto.Medicos.Add(medico);
            _contexto.SaveChanges();

            return RedirectToAction(nameof(Detalhes), medico.MedicoId);
        }
                
        public ActionResult Edit(int id)
        {
            return View();
        }
               
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
               
        public ActionResult Delete(int id)
        {
            var medico = _repositorioMedico.Obter(id);
            var model = _mapper.Map<MedicoViewModel>(medico);
            return View(model);
        }
        
        [HttpPost]       
        public ActionResult Deletar(int MedicoId)
        {
            var medico = _repositorioMedico.Obter(MedicoId);
            _contexto.Medicos.Remove(medico);
            _contexto.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
