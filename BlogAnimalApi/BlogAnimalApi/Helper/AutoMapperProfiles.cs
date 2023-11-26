using AutoMapper;
using BlogAnimalApi.DTO;
using BlogAnimalApi.DTO.requestDTO;
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
            CreateMap<TradePost, TradeDTO>().ReverseMap();
            CreateMap<TradeComment, TradeCommentDTO>().ReverseMap();
            //
            CreateMap<Account, SignInDTO>().ReverseMap();
            CreateMap<Account, SignUpDTO>().ReverseMap();
            CreateMap<Post, CreatePostDTO>().ReverseMap();
            CreateMap<Post, UpdatePostDTO>().ReverseMap();
            CreateMap<TradePost, CreateTradeDTO>().ReverseMap();
            CreateMap<Blog, createBlogDTO>().ReverseMap();
        }
    }
}

