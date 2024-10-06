using Microsoft.AspNetCore.Identity;

namespace RegistroV2.Models
{
    public class UserAplication:IdentityUser
    {
        public string? Nome { get; set; }
        //relacionado ao Post
        public List<Post> Posts { get; set; }

    }
}
