using BlogAnimalApi.Entity;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace BlogAnimalApi.Repository
{
    public class PostRepository : Repository<Post>
    {
        public PostRepository(BlogAnimalContext _context) : base(_context)
        {
        }

        public async Task<List<Post>> getAll()
        {
            return await context.Posts.Include(p => p.PostLikes).Include(p => p.PostComments).Include(p => p.Account).ToListAsync();    
        }

        public async Task<Post> getOne(string id)
        {
            return await context.Posts.Include(p => p.PostLikes).Include(p => p.PostComments).Include(p => p.Account).FirstOrDefaultAsync(p => p.PostId.Equals(id));
        }
    }
}
