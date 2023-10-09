using BlogAnimalApi.Entity;
using Repository;

namespace BlogAnimalApi.Repository
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(BlogAnimalContext _context) : base(_context)
        {
        }
    }
}
