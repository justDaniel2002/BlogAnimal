using BlogAnimalApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAnimalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogService blogService;
        public BlogController(BlogService blogService)
        {
            this.blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllBlog()
        {
            var result = await blogService.getAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getBlogById(string id)
        {
            var result = await blogService.getOne(id);
            return Ok(result);
        }
    }
}
