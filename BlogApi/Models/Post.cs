using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlogApi.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Category { get; set; }
        public string Description { get; set; }
        public bool IsCommentEnable { get; set; } = true;
        public int BloggerId { get; set; }
        public DateTime RegTime { get; set; }= DateTime.Now;
        public DateTime ModTime { get; set; }=DateTime.Now;
        public virtual Blogger Bloggers { get; set; }

    }
}
