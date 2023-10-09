using BlogAnimalApi.Entity;
using Repository;

namespace BlogAnimalApi.Repository
{
    public class BlogCommentRepository : Repository<BlogComment>
    {
        public BlogCommentRepository(BlogAnimalContext _context) : base(_context)
        {
        }
    }
}
