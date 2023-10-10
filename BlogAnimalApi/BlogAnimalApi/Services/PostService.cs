using AutoMapper;
using BlogAnimalApi.DTO;
using BlogAnimalApi.Entity;
using BlogAnimalApi.Repository;

namespace BlogAnimalApi.Services
{
    public class PostService : Service
    {
        private readonly PostRepository postRepo;
        public PostService(PostRepository _postRepository, IMapper _mapper) : base(_mapper)
        {
            this.postRepo = _postRepository;
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
    }
}
