using BlogAnimalApi.Entity;
using BlogAnimalApi.Helper;
using Microsoft.AspNetCore.Components.Forms;
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

        public async Task<List<Account>> getAll()
        {
            return await context.Accounts.Include(a => a.Role).ToListAsync();
        }

        public async Task<Account> getOne(string accountId)
        {
            return await context.Accounts.FindAsync(accountId);
        }

        public async Task<string> editPassword(string accountId, string oldpasswod, string newpassword)
        {
            Account acc = await context.Accounts.FindAsync(accountId);

            if(acc != null&& acc != null && acc.HashPassword.Equals(oldpasswod))
            {
                acc.HashPassword = util.hashPassword(newpassword);
                await context.SaveChangesAsync();
                return "succesfully";
            }

            return "password incorrect";
        }

       public async Task update(Account acc)
        {
            Account accDB = await context.Accounts.FindAsync(acc.AccountId);
            accDB.Email = acc.Email;
            accDB.Username = acc.Username;
            accDB.Contact = acc.Contact;
            accDB.Facebook = acc.Facebook;
            await context.SaveChangesAsync();
        }

    }
}
