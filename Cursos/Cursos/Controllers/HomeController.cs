using Cursos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cursos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        private static IList<Curso> cursos =  new List<Curso>()     {
                
            new Curso() {
                ID = 1,
                Descricao = "Asp Net MVC",
                CargaHoraria = 40
                },
                new Curso() {
                ID = 2,
                Descricao = "Banco de dados",
                CargaHoraria = 30
                },
                new Curso() {
                ID = 3,
                Descricao = "React",
                CargaHoraria = 60
                },
                new Curso() {
                ID = 4,
                Descricao = "HTML e CSS",
                CargaHoraria = 20
                }
                    };



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Curso()
        {

            // PARÂMETRO DO INSTANCIAMENTO DO OBJETO CURSO
            return View(cursos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}