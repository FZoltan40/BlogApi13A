namespace BlogApi.Models.Dtos
{
    public class AddBloggerDto
    {
        public string Name { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
    }
}
