using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_notaAluno.Data;

namespace Sistema_notaAluno.Controllers
{
    public class ContaController : Controller
    {
        private readonly AppDbContext _context;

        public ContaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var service = new UsuarioService(_context);
            var usuario = service.Autenticar(email, senha); // Retorna o usuário encontrado

            if (usuario != null)
            {
                // SALVA O E-MAIL E O TIPO NA SESSÃO
                HttpContext.Session.SetString("UsuarioLogado", usuario.Email);
                HttpContext.Session.SetString("TipoUsuario", usuario.Tipo);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "E-mail ou senha inválidos.");
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Cadastro() => View();

        [HttpPost]
        public IActionResult Cadastro(string email, string senha, string tipo)
        {
            var service = new UsuarioService(_context);
            if (service.Cadastrar(email, senha, tipo))
            {
                TempData["Sucesso"] = "Cadastrado com sucesso! Faça o login.";
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Erro ao cadastrar. E-mail já existe.");
            return View();
        }
    }
}