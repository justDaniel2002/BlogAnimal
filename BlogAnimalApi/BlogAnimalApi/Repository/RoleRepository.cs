using BlogAnimalApi.Entity;
using Repository;

namespace BlogAnimalApi.Repository
{
    public class RoleRepository : Repository<Role>
    {
        public RoleRepository(BlogAnimalContext _context) : base(_context)
        {
        }
    }
}
