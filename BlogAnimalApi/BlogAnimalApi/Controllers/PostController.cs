using BlogAnimalApi.DTO;
using BlogAnimalApi.DTO.requestDTO;
using BlogAnimalApi.Entity;
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
                Post post = await postService.CreatePost(cPostDTO);
                return Ok(post);
            }catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> updatePost(UpdatePostDTO postDTO)
        {
            try
            {
                Post post = await postService.UpdatePost(postDTO);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

        [HttpPut("uploadImg/{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> updateImagePost(List<IFormFile> Images, string id)
        {
            try
            {
                await postService.updateUploadImg(Request.Form.Files, id);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("uploadImg/{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> uploadImagePost(List<IFormFile> Images, string id)
        {
            try
            {
                await postService.uploadImg(Request.Form.Files, id);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("uploadComment/{postId}/{accId}")]
        public async Task<IActionResult> uploadComment(string comment, string postId, string accId)
        {
            try
            {
                await postService.uploadComment(comment, postId, accId);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("likePost/{postId}/{accId}")]
        public async Task<IActionResult> likePost(string postId, string accId)
        {
            try
            {
                await postService.likePost(postId, accId);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletePost(string id)
        {
            try
            {
                await postService.deletePost(id);
                return StatusCode(StatusCodes.Status200OK);
            }catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("search/{searchStr}")]
        public async Task<IActionResult> searchPost(string searchStr)
        {
            var result = await postService.search(searchStr);
            return Ok(result);
        }

        [HttpPut("secure/{postId}")]
        public async Task<IActionResult> securePost(string postId)
        {
            try
            {
                await postService.secure(postId);
                return StatusCode(StatusCodes.Status200OK);
            }catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
