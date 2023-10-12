using BlogAnimalApi.Entity;
using Repository;

namespace BlogAnimalApi.Repository
{
    public class BlogTypeRepository : Repository<BlogType>
    {
        public BlogTypeRepository(BlogAnimalContext _context) : base(_context)
        {
        }
    }
}
