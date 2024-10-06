using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegistroV2.Dados;
using RegistroV2.Models; 
namespace RegistroV2.Controllers
{
	public class PageController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<UserAplication> _userManager;
		public PageController(ApplicationDbContext context, UserManager<UserAplication> userManager)
		{
			_context = context;
			_userManager = userManager;
		}
		[HttpGet]
		public IActionResult Registrar()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Registrar(Post post)
		{
			if (ModelState.IsValid)
			{
				//gera a slug
				post.GenerateSlug();

				//salva o post
				_context.Posts.Add(post);
				_context.SaveChanges();

				//redireciona para a lista
				return RedirectToAction("Index", "Home");
			}

			//se tiver um erro retorna o formulario
			return View(post);
		}

    }
}
