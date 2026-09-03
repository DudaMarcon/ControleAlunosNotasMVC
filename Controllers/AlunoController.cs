using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_notaAluno.Data;
using Sistema_notaAluno.ViewModels;

namespace Sistema_notaAluno.Controllers
{
    public class AlunoController : Controller
    {
        private readonly AppDbContext _context;

        public AlunoController(AppDbContext context)
        {
            _context = context;
        }

        // Lista os alunos cadastrados no banco
        public async Task<IActionResult> Index()
        {
            var alunos = await _context.Alunos.ToListAsync();

            return View(alunos);
        }

        // Mostra a tela de cadastro
        public IActionResult Criar()
        {
            return View();
        }
        // Mostra a tela de cadastro de nota
        public async Task<IActionResult> CriarNota()
        {
            var alunos = await _context.Alunos.ToListAsync();

            ViewBag.Alunos = alunos;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarNota(CriarNotaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Alunos = await _context.Alunos.ToListAsync();
                return View(model);
            }

            var nota = new Models.Nota
            {
                AlunoId = model.AlunoId,
                Disciplina = model.Disciplina,
                Nota1 = model.Nota1,
                Nota2 = model.Nota2
            };

            _context.Notas.Add(nota);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Detalhes), new { id = model.AlunoId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(CriarAlunoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var aluno = new Models.Aluno
            {
                Nome = model.Nome,
                Turma = model.Turma,
                Matricula = model.Matricula,
                Status = model.Status,
                Curso = model.Curso
            };

            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Mostra os detalhes de um aluno
        public async Task<IActionResult> Detalhes(int id)
{
    var aluno = await _context.Alunos
        .Include(a => a.Notas)
        .FirstOrDefaultAsync(a => a.Id == id);

    if (aluno == null)
    {
        return NotFound();
    }

    return View(aluno);
}
    }
}