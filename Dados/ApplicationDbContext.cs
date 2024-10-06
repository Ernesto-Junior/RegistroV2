using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegistroV2.Models;

namespace RegistroV2.Dados
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {}
        public DbSet<Post> Posts { get; set; }

        public DbSet<Page> Pages { get; set; }
        public DbSet<UserAplication> UserAplications { get; set; }

    }
}
