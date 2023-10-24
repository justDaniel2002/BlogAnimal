using BlogAnimalApi.DTO.requestDTO;
using BlogAnimalApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAnimalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService postService;
        public PostController(PostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllPost()
        {
            var result = await postService.getAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getPostById(string id)
        {
            var result = await postService.getOne(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> createPost(CreatePostDTO cPostDTO)
        {
            try
            {
                await postService.CreatePost(cPostDTO);
                return StatusCode(StatusCodes.Status201Created);
            }catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("uploadImg/{id}")]
        public async Task<IActionResult> uploadImagePost(List<IFormFile> files, string id)
        {
            try
            {
                /*await postService.CreatePost(cPostDTO);*/
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
