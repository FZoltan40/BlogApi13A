using BlogApi.Models;
using BlogApi.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
