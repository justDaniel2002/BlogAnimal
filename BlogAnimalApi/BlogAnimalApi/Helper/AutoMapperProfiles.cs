using AutoMapper;
using BlogAnimalApi.DTO;
using BlogAnimalApi.Entity;

namespace BlogAnimalApi.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<PetType, PetTypeDTO>().ReverseMap();
            CreateMap<BlogType, BlogTypeDTO>().ReverseMap();
            CreateMap<BlogComment, BlogCommentDTO>().ReverseMap();
            CreateMap<Blog, BlogDTO>().ReverseMap();
            CreateMap<PostComment, PostCommentDTO>().ReverseMap();
            CreateMap<PostLike, PostLikeDTO>().ReverseMap();
            CreateMap<Post, PostDTO>().ReverseMap();
        }
    }
}

