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
            return await context.Posts.Include(p => p.PostLikes).Include(p => p.PostComments).ThenInclude(p => p.Account).ToListAsync();    
        }

        public async Task<Post> getOne(string id)
        {
            return await context.Posts.Include(p => p.PostLikes).Include(p => p.PostComments).ThenInclude(p => p.Account).FirstOrDefaultAsync(p => p.PostId.Equals(id));
        }

        public async Task<Post> uploadImageString(string images, string id)
        {
            Post post = await context.Posts.FirstOrDefaultAsync(p => p.PostId.Equals(id));
            if (post!= null)
            {
                post.Images = images;
                await context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine(post);
            }
            return post;
        }

        public async Task delOne(string postId)
        {
            Post post = await context.Posts.Include(p=> p.PostComments).Include(p=>p.PostLikes).FirstOrDefaultAsync(p => p.PostId.Equals(postId));
            if (post != null)
            {
                context.Posts.Remove(post);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Post>> search(string search)
        {
            return await context.Posts.Include(p => p.PostLikes).Include(p => p.PostComments).Include(p => p.Account)
                .Where(p => p.Title.ToLower().Contains(search.ToLower())||p.Content.ToLower().Contains(search.ToLower())).ToListAsync();
        }
    }
}
