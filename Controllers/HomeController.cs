using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sistema_notaAluno.Models;

namespace Sistema_notaAluno.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Aluno()
        {
            return View();
        }

        public IActionResult Notas()
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
