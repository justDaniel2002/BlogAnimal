using AutoMapper;
using BlogAnimalApi.DTO;
using BlogAnimalApi.DTO.requestDTO;
using BlogAnimalApi.Entity;
using BlogAnimalApi.Repository;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using BlogAnimalApi.Helper;
using System.Net;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

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

        public async Task<Post> CreatePost(CreatePostDTO createPostDTO)
        {
            Post post = mapper.Map<Post>(createPostDTO);
            return await postRepo.add(post);
        }

        public async Task uploadImg(IFormFileCollection files, string postId)
        {
            string images = "";
            foreach (var file in files)
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream()),
                    PublicId = "post_img"+Guid.NewGuid(), // Provide a unique public ID for each file
                    Folder = "PostImages" // Replace "your-folder-name" with the desired folder name
                };

                var uploadResult = cloudinaryConfig.cloudinary.Upload(uploadParams);
                // Process the uploadResult as needed (e.g., check for success, retrieve URLs, etc.)
                if (uploadResult.StatusCode == HttpStatusCode.OK)
                {
                    // The file was uploaded successfully
                    images += uploadResult.SecureUri.AbsoluteUri+",";
                    // You can store or use the publicUrl as needed
                    await postRepo.uploadImageString(images, postId);
                }
                else
                {
                    Console.WriteLine(uploadResult.Error);
                }
            }
           
        }

        public async Task uploadImgByte(List<byte[]> Images, string postId)
        {
            string images = "";
            foreach (var fileData in Images)
            {
                // Generate a unique name for each file (e.g., using a GUID)
                string uniqueFileName = Guid.NewGuid().ToString();

                // Convert the byte array to a stream
                using (Stream stream = new MemoryStream(fileData))
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(uniqueFileName, stream), // Use the unique name for the file
                    };

                    var uploadResult = cloudinaryConfig.cloudinary.Upload(uploadParams);

                    // Handle the upload result for each file
                    if (uploadResult.StatusCode == HttpStatusCode.OK)
                    {
                        images += uploadResult.SecureUri.AbsoluteUri + ",";
                        // You can store or use the publicUrl as needed
                        await postRepo.uploadImageString(images, postId);
                    }
                    else
                    {
                        // Handle the upload failure for this file
                    }
                }
            }
        }

    }
}
