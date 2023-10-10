using BlogAnimalApi.Entity;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace BlogAnimalApi.Repository
{
    public class BlogRepository : Repository<Blog>
    {
        public BlogRepository(BlogAnimalContext _context) : base(_context)
        {
        }

        public async Task<List<Blog>> getAll()
        {
            return await context.Blogs.Include(b => b.Account).Include(b => b.Type).Include(b => b.BlogComments).Include(b => b.BlogTags).ToListAsync();
        }

        public async Task<Blog> get(string id)
        {
            return await context.Blogs.Include(b => b.Account).Include(b => b.Type).Include(b => b.BlogComments).Include(b => b.BlogTags).FirstOrDefaultAsync(b => b.BlogId.Equals(id));
        }
    }
}
