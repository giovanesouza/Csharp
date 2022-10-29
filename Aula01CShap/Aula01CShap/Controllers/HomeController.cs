using Aula01CShap.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aula01CShap.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // CRIAÇÃO DE VIEW, ONDE O NOME DELA SERÁ O MESMO DO MÉTODO
        public IActionResult Recode()
        {
            return View();
        }




    }
}