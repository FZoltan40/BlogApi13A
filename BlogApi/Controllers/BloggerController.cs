using BlogApi.Models;
using BlogApi.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggerController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddNewBlogger(AddBloggerDto addBloggerDto)
        {
            try
            {
                using (var context = new BlogDbContext())
                {
                    var blogger = new Blogger
                    {
                        Name = addBloggerDto.Name,
                        Password = addBloggerDto.Password,
                        Email = addBloggerDto.Email
                    };

                    if (blogger != null)
                    {
                        context.bloggers.Add(blogger);
                        context.SaveChanges();
                        return StatusCode(201, new { message = "Sikeres felvétel", result = blogger });
                    }

                    return NotFound(new { message = "Sikertlen felvétel", result = blogger });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, result = "" });
            }
          

        }

        [HttpGet]
        public ActionResult GetBlogger() 
        {
            try
            {
                using (var context = new BlogDbContext())
                {
                    var bloggers = context.bloggers.ToList();
                    return Ok(new { messaege = "Sikeres lekérdezés", result =bloggers});
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { messaege = ex.Message, result = "" });
            }
        }

        [HttpGet("withPosts")]
        public ActionResult GetBloggersWithPosts()
        {
            try
            {
                using (var context = new BlogDbContext())
                {
                    var bloggersWithPosts = context.bloggers.Include(x=>x.Posts).ToList();
                    return Ok(new { messaege = "Sikeres lekérdezés", result = bloggersWithPosts });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { messaege = ex.Message, result = "" });
            }
        }

        [HttpGet("getByIdWithPosts")]
        public ActionResult GetBloggersByIdWithPosts(int id)
        {
            try
            {
                using (var context = new BlogDbContext())
                {
                    var bloggerWithPosts = context.bloggers.Include(x => x.Posts).FirstOrDefault(x => x.Id == id);

                    var blogger = new { bloggerWithPosts.Name, Posts = bloggerWithPosts.Posts.Select(x => new { x.Category, x.Description }) };
                    return Ok(new { messaege = "Sikeres lekérdezés", result = blogger });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { messaege = ex.Message, result = "" });
            }
        }
    }
}
