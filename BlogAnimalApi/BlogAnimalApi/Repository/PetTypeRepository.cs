using BlogAnimalApi.Entity;
using Repository;

namespace BlogAnimalApi.Repository
{
    public class PetTypeRepository : Repository<PetType>
    {
        public PetTypeRepository(BlogAnimalContext _context) : base(_context)
        {
        }
    }
}
