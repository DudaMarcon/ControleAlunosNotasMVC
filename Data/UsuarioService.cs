using System.Linq;
using Sistema_notaAluno.Models;

namespace Sistema_notaAluno.Data
{
    public class UsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        // Modificado para aceitar o 'tipo'
        public bool Cadastrar(string email, string senha, string tipo)
        {
            if (_context.Usuarios.Any(u => u.Email == email))
                return false; 

            var usuario = new Usuario 
            { 
                Email = email, 
                Senha = senha, 
                Tipo = tipo 
            };
            
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return true;
        }

        // Retorna o objeto Usuario inteiro (ou null se falhar) para pegarmos o tipo no login
        public Usuario Autenticar(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}