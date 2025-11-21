using BlogApi.Models;
using BlogApi.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddNewPost(AddPostDto addPostDto)
        {
            try
            {
                using (var context = new BlogDbContext())
                {
                    var post = new Post 
                    { 
                        Category = addPostDto.Category,
                        Description = addPostDto.Description,
                        BloggerId = addPostDto.BloggerId 
                    };

                    if (post != null)
                    {
                        context.posts.Add(post);
                        context.SaveChanges();
                        return StatusCode(201, new { message = "Sikeres hozzáadás", result = post});
                    }

                    return StatusCode(404, new { message = "Sikertelen hozzáadás", result = post });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }

    }
}
