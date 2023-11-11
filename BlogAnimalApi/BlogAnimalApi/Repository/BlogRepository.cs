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
            return await context.Blogs.Include(b => b.BlogType).Include(b => b.PetType).Include(b => b.BlogComments).ThenInclude(c=> c.Account).Include(b => b.Account).Include(b => b.BlogTags).OrderByDescending(b => b.CreatedDate).ToListAsync();
        }

        public async Task<Blog> get(string id)
        {
            return await context.Blogs.Include(b => b.Account).Include(b => b.BlogType).Include(b => b.PetType).Include(b => b.BlogComments).ThenInclude(c => c.Account).Include(b => b.BlogTags).FirstOrDefaultAsync(b => b.BlogId.Equals(id));
        }

        public async Task<List<Blog>> getBlogByType(int typeid)
        {
            return await context.Blogs.Include(b => b.Account).Include(b => b.BlogType).Include(b => b.PetType).Include(b => b.BlogComments).Include(b => b.BlogTags).Where(b => b.BlogTypeId == typeid).ToListAsync();
        }

        public async Task<Blog> delOne(string id)
        {
            Blog blog = await context.Blogs.Include(b => b.BlogComments).FirstOrDefaultAsync(b => b.BlogId.Equals(id));
            if(blog != null)
            {
                context.Blogs.Remove(blog);
                await context.SaveChangesAsync();
            }
            return blog;

        }

        public async Task<List<Blog>> search(string search)
        {
            return await context.Blogs.Include(b => b.BlogType).Include(b => b.PetType).Include(b => b.BlogComments).ThenInclude(c => c.Account).Include(b => b.Account).Include(b => b.BlogTags)
                .Where(b => b.Title.ToLower().Contains(search.ToLower())||b.Content.ToLower().Contains(search.ToLower())).ToListAsync();
        }
    }
}
