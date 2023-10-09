using BlogAnimalApi.Entity;
using Repository;

namespace BlogAnimalApi.Repository
{
    public class AccountRepository : Repository<Account>
    {
        public AccountRepository(BlogAnimalContext _context) : base(_context)
        {
        }
    }
}
