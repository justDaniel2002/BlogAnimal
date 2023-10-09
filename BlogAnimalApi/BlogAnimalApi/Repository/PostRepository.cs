using BlogAnimalApi.Entity;
using Repository;

namespace BlogAnimalApi.Repository
{
    public class PostRepository : Repository<Post>
    {
        public PostRepository(BlogAnimalContext _context) : base(_context)
        {
        }
    }
}
