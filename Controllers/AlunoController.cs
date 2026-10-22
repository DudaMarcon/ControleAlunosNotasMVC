
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_notaAluno.Data;
using Sistema_notaAluno.ViewModels;
using System.Globalization;

namespace Sistema_notaAluno.Controllers
{
    public class AlunoController : Controller
    {
        private readonly AppDbContext _context;

        public AlunoController(AppDbContext context)
        {
            _context = context;
        }

        // Lista, busca e filtra os alunos
        public async Task<IActionResult> Index(
            string? busca,
            string? turma,
            string? status,
            string? curso)
        {
            var query = _context.Alunos.AsQueryable();

            // Busca por nome ou matrícula
            if (!string.IsNullOrWhiteSpace(busca))
            {
                busca = busca.Trim();

                query = query.Where(a =>
                    a.Nome.Contains(busca) ||
                    a.Matricula.Contains(busca));
            }

            // Filtro por turma
            if (!string.IsNullOrWhiteSpace(turma))
            {
                query = query.Where(a => a.Turma == turma);
            }

            // Filtro por status
            if (!string.IsNullOrWhiteSpace(status))
            {
                query = query.Where(a => a.Status == status);
            }

            // Filtro por curso
            if (!string.IsNullOrWhiteSpace(curso))
            {
                query = query.Where(a => a.Curso == curso);
            }

            // Ordena e consulta os resultados
            var alunos = await query
                .OrderBy(a => a.Nome)
                .ToListAsync();

            // Mantém os valores informados na tela
            ViewBag.Busca = busca;
            ViewBag.Turma = turma;
            ViewBag.Status = status;
            ViewBag.Curso = curso;

            // Carrega as opções disponíveis para os filtros
            ViewBag.Turmas = await _context.Alunos
                .Select(a => a.Turma)
                .Distinct()
                .OrderBy(t => t)
                .ToListAsync();

            ViewBag.StatusList = await _context.Alunos
                .Select(a => a.Status)
                .Distinct()
                .OrderBy(s => s)
                .ToListAsync();

            ViewBag.Cursos = await _context.Alunos
                .Select(a => a.Curso)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            return View(alunos);
        }

        // Mostra a tela de cadastro de aluno
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        // Cadastra um aluno
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(
            CriarAlunoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var cultura = new CultureInfo("pt-BR");

            var aluno = new Models.Aluno
            {
                Nome = cultura.TextInfo.ToTitleCase(
                    model.Nome.Trim().ToLower(cultura)
                ),
                Turma = model.Turma,
                Matricula = model.Matricula,
                Status = model.Status,
                Curso = model.Curso
            };

            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Mostra a tela de cadastro de nota
        [HttpGet]
        public async Task<IActionResult> CriarNota()
        {
            ViewBag.Alunos = await _context.Alunos
                .OrderBy(a => a.Nome)
                .ToListAsync();

            return View();
        }

        // Cadastra uma nota para um aluno
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarNota(
            CriarNotaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Alunos = await _context.Alunos
                    .OrderBy(a => a.Nome)
                    .ToListAsync();

                return View(model);
            }

            // Confirma que o aluno selecionado existe
            var alunoExiste = await _context.Alunos
                .AnyAsync(a => a.Id == model.AlunoId);

            if (!alunoExiste)
            {
                ModelState.AddModelError(
                    nameof(model.AlunoId),
                    "O aluno selecionado não foi encontrado."
                );

                ViewBag.Alunos = await _context.Alunos
                    .OrderBy(a => a.Nome)
                    .ToListAsync();

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

            return RedirectToAction(
                nameof(Detalhes),
                new { id = model.AlunoId }
            );
        }

        // Mostra os detalhes e as notas do aluno
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
