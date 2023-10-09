using BlogAnimalApi.Entity;
using Repository;

namespace BlogAnimalApi.Repository
{
    public class BlogRepository : Repository<Blog>
    {
        public BlogRepository(BlogAnimalContext _context) : base(_context)
        {
        }
    }
}
