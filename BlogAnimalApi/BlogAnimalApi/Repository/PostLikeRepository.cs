using BlogAnimalApi.Entity;
using Repository;

namespace BlogAnimalApi.Repository
{
    public class PostLikeRepository : Repository<PostLike>
    {
        public PostLikeRepository(BlogAnimalContext _context) : base(_context)
        {
        }
    }
}
