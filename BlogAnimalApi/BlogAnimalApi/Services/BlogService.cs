using AutoMapper;
using BlogAnimalApi.DTO;
using BlogAnimalApi.Entity;
using BlogAnimalApi.Repository;
using System.Numerics;

namespace BlogAnimalApi.Services
{
    public class BlogService : Service
    {
        private readonly BlogRepository blogRepo;
        private readonly TagRepository tagRepo;
        private readonly BlogTypeRepository blogTypeRepo;
        public BlogService(BlogRepository _blogRepo, IMapper _mapper, TagRepository _tagRepo, BlogTypeRepository _blogTypeRepo) : base(_mapper)
        {
            blogRepo = _blogRepo;
            tagRepo = _tagRepo;
            blogTypeRepo = _blogTypeRepo;
        }

        public async Task<List<BlogDTO>> convertBlogToDto(List<Blog> blogs)
        {
            //map from list of blog -> list of blog dto
            List<BlogDTO> blogDTOs = mapper.Map<List<BlogDTO>>(blogs);

            //loop in blog list to get blogtags
            foreach (Blog b in blogs)
            {
                List<Tag> tags = new List<Tag>();
                foreach (BlogTag bt in b.BlogTags)
                {

                    int tag_id = Convert.ToInt32(bt.TagId);
                    Tag tag = await tagRepo.getOne(tag_id);
                    if (tag != null)
                        tags.Add(tag);

                }

                //if list of tag > 0, update tagDTO list of blogDTO list
                if (tags.Count > 0)
                {
                    List<TagDTO> tagDTOs = mapper.Map<List<TagDTO>>(tags);
                    BlogDTO blogDTO = blogDTOs.FirstOrDefault(dto => dto.BlogId.Equals(b.BlogId));
                    blogDTO.Tags = tagDTOs;
                }
            }

            return blogDTOs;
        }

        public async Task<List<BlogDTO>> getAll()
        {
            List<Blog> blogs = await blogRepo.getAll();

            //map from list of blog -> list of blog dto
            List<BlogDTO> blogDTOs = await convertBlogToDto(blogs);

            return blogDTOs;
        }

        public async Task<BlogDTO> getOne(string id)
        {
            Blog blog = await blogRepo.get(id);

            //map from blog -> blog dto
            BlogDTO blogDTO = mapper.Map <BlogDTO> (blog);


            List<Tag> tags = new List<Tag>();
            foreach (BlogTag bt in blog.BlogTags)
            {
                if (bt.Tag != null)
                {
                    tags.Add(bt.Tag);
                }
            }

            //if list of tag > 0, update tagDTO list of blogDTO list
            if (tags.Count > 0)
            {
                List<TagDTO> tagDTOs = mapper.Map<List<TagDTO>>(tags);
                blogDTO.Tags = tagDTOs;
            }


            return blogDTO;
        }

        public async Task<List<BlogTypeDTO>> getAllBlogType()
        {
            List<BlogType> blogTypes = await blogTypeRepo.getAll();
            List<BlogTypeDTO> blogTypeDTOs = mapper.Map<List<BlogTypeDTO>>(blogTypes);
            return blogTypeDTOs;
        }

        public async Task<List<BlogDTO>> getAllBlogByType(int typeid)
        {
            List<Blog> blogs = await blogRepo.getBlogByType(typeid);

            //map from list of blog -> list of blog dto
            List<BlogDTO> blogDTOs = await convertBlogToDto(blogs);

            return blogDTOs;
        }


    }
}
