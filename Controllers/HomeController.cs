using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sistema_notaAluno.Models;

namespace Sistema_notaAluno.Controllers
{
    public class HomeController : Controller
    {
        // Lista de alunos
        private static List<Aluno> alunos = new List<Aluno>
        {
            new Aluno
            {
                Id = 1,
                Nome = "Felipe Drigo Binatto",
                Turma = "2° EM",
                Curso = "Desenvolvimento de Sistemas",
                Status = "Cursando",
                Matricula = "20250860077",

                Notas = new List<Nota>
                {
                    new Nota
                    {
                        Disciplina = "Matemática",
                        Nota1 = 8,
                        Nota2 = 7
                    },

                    new Nota
                    {
                        Disciplina = "Português",
                        Nota1 = 9,
                        Nota2 = 10
                    },

                    new Nota
                    {
                        Disciplina = "Programação",
                        Nota1 = 10,
                        Nota2 = 9
                    },

                    new Nota
                    {
                        Disciplina = "Banco de Dados",
                        Nota1 = 5,
                        Nota2 = 6
                    }
                }
            }
        };

        public IActionResult Index()
        {
            return View();
        }

        // Página da lista de alunos
        public IActionResult Aluno()
        {
            return View(alunos);
        }

        public IActionResult Notas()
        {
            return View();
        }

        // Página de detalhes / boletim
        public IActionResult Detalhes(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        [ResponseCache(Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id
                ?? HttpContext.TraceIdentifier
            });
        }
    }
}