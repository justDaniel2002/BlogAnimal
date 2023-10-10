using BlogAnimalApi.Entity;
using BlogAnimalApi.Helper;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace BlogAnimalApi.Repository
{
    public class AccountRepository : Repository<Account>
    {
        private readonly Util util;

        public AccountRepository(BlogAnimalContext _context, Util _util) : base(_context)
        {
            util = _util;
        }

        public async Task<Account> getByEmailAndPass(string email, string pass)
        {
            string hashPass = util.hashPassword(pass);
            return await context.Accounts.FirstOrDefaultAsync(a => a.Email.Equals(email) && a.HashPassword.Equals(hashPass));
        }

    }
}
