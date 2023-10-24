using AutoMapper;
using BlogAnimalApi.DTO;
using BlogAnimalApi.DTO.requestDTO;
using BlogAnimalApi.Entity;
using BlogAnimalApi.Repository;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using BlogAnimalApi.Helper;
using System.Net;

namespace BlogAnimalApi.Services
{
    public class PostService : Service
    {
        private readonly PostRepository postRepo;
        private readonly CloudinaryConfig cloudinaryConfig;
        public PostService(PostRepository _postRepository, CloudinaryConfig cloudinaryConfig, IMapper _mapper) : base(_mapper)
        {
            this.postRepo = _postRepository;
            this.cloudinaryConfig = cloudinaryConfig;
        }

        public async Task<List<PostDTO>> getAll()
        {
            List<Post> posts = await postRepo.getAll();
            List<PostDTO> postDTOs = mapper.Map<List<PostDTO>>(posts);

            return postDTOs;
        }

        public async Task<PostDTO> getOne(string id)
        {
            Post post = await postRepo.getOne(id);
            PostDTO postDTO = mapper.Map<PostDTO>(post);

            return postDTO;
        }

        public async Task CreatePost(CreatePostDTO createPostDTO)
        {
            Post post = mapper.Map<Post>(createPostDTO);
            await postRepo.add(post);
        }

        public async Task uploadImg(List<IFormFile> files, string postId)
        {
            string images = "";
            foreach (var file in files)
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream()),
                    PublicId = "olympic_flag", // Provide a unique public ID for each file
                    Folder = "your-folder-name" // Replace "your-folder-name" with the desired folder name
                };

                var uploadResult = cloudinaryConfig.cloudinary.Upload(uploadParams);
                // Process the uploadResult as needed (e.g., check for success, retrieve URLs, etc.)
                if (uploadResult.StatusCode == HttpStatusCode.OK)
                {
                    // The file was uploaded successfully
                    images += uploadResult.SecureUri.AbsoluteUri+",";
                    // You can store or use the publicUrl as needed
                }
            }
            postRepo.uploadImageString(images, postId);
        }

    }
}
