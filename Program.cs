using Microsoft.EntityFrameworkCore;
using Sistema_notaAluno.Data;

namespace Sistema_notaAluno
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona suporte a Controladores com Views
            builder.Services.AddControllersWithViews();

            // Configuração do banco de dados SQLite
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            // ==========================================
            // ADIÇÕES PARA O LOGIN E SESSÃO FUNCIONAREM:
            // ==========================================
            builder.Services.AddHttpContextAccessor(); // Permite ler a sessão nas Views (_Layout)
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo que a sessão expira
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
                {
                     var services = scope.ServiceProvider;
                     var context = services.GetRequiredService<AppDbContext>();
                     context.Database.EnsureCreated(); // Cria o banco e as tabelas automaticamente se não existirem
                }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            // ==========================================
            // HABILITA A SESSÃO ANTES DA AUTORIZAÇÃO:
            // ==========================================
            app.UseSession(); 

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated(); // Isso cria a tabela "Usuarios" automaticamente
            }

            app.Run();
        }
    }
}