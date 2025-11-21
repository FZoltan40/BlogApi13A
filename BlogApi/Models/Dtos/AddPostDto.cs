namespace BlogApi.Models.Dtos
{
    public class AddPostDto
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public int BloggerId { get; set; }
    }
}
