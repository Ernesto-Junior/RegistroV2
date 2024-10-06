using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroV2.Dados;
using RegistroV2.Models;
using System.Diagnostics;

namespace RegistroV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // Adicione o DbContext aqui

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger) // Injetando o DbContext no construtor
        {
            _context = context; // Atribuindo o contexto
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _context.Posts.ToListAsync(); // Busca todos os posts
            return View(posts); // Passa a lista de posts para a view
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

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Detalhe(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post); // Passa o post para a view de detalhes
        }
    }
}
