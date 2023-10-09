using BlogAnimalApi.Entity;
using Repository;

namespace BlogAnimalApi.Repository
{
    public class PostCommentRepository : Repository<PostComment>
    {
        public PostCommentRepository(BlogAnimalContext _context) : base(_context)
        {
        }
    }
}
