using Microsoft.AspNetCore.Identity;
using RegistroV2.Dados;
using RegistroV2.Models;

namespace RegistroV2.Utilites
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UserAplication> _userManage;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(ApplicationDbContext context, UserManager<UserAplication> userManage, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManage = userManage;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (!_roleManager.RoleExistsAsync(WebsiteRoles.WebsiteAdmin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.WebsiteAdmin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.WebsiteUsers)).GetAwaiter().GetResult();
                _userManage.CreateAsync(new UserAplication()
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    Nome = "SuperAdmin",
                }, "Admin@0011").Wait();

                var appUser = _context.UserAplications.FirstOrDefault(x => x.Email == "admin@gmail.com");
                if (appUser != null)
                {
                    _userManage.AddToRoleAsync(appUser, WebsiteRoles.WebsiteAdmin).GetAwaiter().GetResult();
                }

                var listOfPage = new List<Page>() {

                new Page()
                    {
                         Title = "Registrar",
                         Slug = "Registrar"
                    },
                new Page()
                    {
                         Title = "Registro",
                         Slug = "Registro"
                    }

                };

                _context.Pages.AddRange(listOfPage);
                _context.SaveChanges();

            }
        }
    }
}
