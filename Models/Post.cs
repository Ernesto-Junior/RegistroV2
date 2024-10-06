using System.ComponentModel.DataAnnotations;

namespace RegistroV2.Models
{
    public class Post
    {
        public int ID { get; set; }

        //teste
        [Required]
        public string? Nome { get; set; }
        [Required]
        public int NumCodigo { get; set; }
        [Required]
        public string? Descricao { get; set; }
        //relacionado ao UserAplication
        public string? ApplicattionUserId { get; set; }
        public UserAplication? UserAplication { get; set; }
        public DateTime CreadoEm { get; set; } = DateTime.Now;
        public string? Slug { get; set; }

		public void GenerateSlug()
		{
			if (!string.IsNullOrEmpty(Descricao))
			{
				Slug = Descricao.ToLower().Replace(" ", "-");
			}
		}

	}
}
