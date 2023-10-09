using BlogAnimalApi.Entity;
using Repository;

namespace BlogAnimalApi.Repository
{
    public class BlogTagRepository : Repository<BlogTag>
    {
        public BlogTagRepository(BlogAnimalContext _context) : base(_context)
        {
        }
    }
}
