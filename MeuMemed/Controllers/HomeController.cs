using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MeuMemed.Models;
using MeuMemed.Data.IRepositorios;
using MeuMemed.ViewModel.Home;

namespace MeuMemed.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioMedico _repositorioMedico;
        private readonly IRepositorioPaciente _repositorioPessoa;

        public HomeController(ILogger<HomeController> logger, IRepositorioMedico repositorioMedico, IRepositorioPaciente repositorioPessoa)
        {
            _logger = logger;
            _repositorioMedico = repositorioMedico;
            _repositorioPessoa = repositorioPessoa;
        }

        public IActionResult Index()
        {
            var medicos = _repositorioMedico.ObterTodos();
            var pacientes = _repositorioPessoa.ObterTodos();

            var model = new HomeViewModel(medicos, pacientes);

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
