using AutoMapper;
using BlogAnimalApi.DTO;
using BlogAnimalApi.DTO.requestDTO;
using BlogAnimalApi.Entity;
using BlogAnimalApi.Helper;
using BlogAnimalApi.Repository;

namespace BlogAnimalApi.Services
{
    public class AccountService : Service
    {
        private readonly AccountRepository accountRepo;

        public AccountService(IMapper _mapper, AccountRepository _accountRepo) : base(_mapper)
        {
            accountRepo = _accountRepo;
        }

        public async Task<AccountDTO> SignIn(string email, string password)
        {
            Account acc = await accountRepo.getByEmailAndPass(email, password);
            if (acc != null)
            {
                AccountDTO accountDTO = mapper.Map<AccountDTO>(acc);

                bool isBanned = accountDTO.IsBanned ?? false;
                return isBanned ? null : accountDTO;
            }
            else
            {
                return null;
            }
            
        }

        public async Task SignUp(SignUpDTO accountDTO)
        {
            Account account = mapper.Map<Account>(accountDTO);
            await accountRepo.add(account);
        }

        public async Task<List<AccountDTO>> getAll()
        {
            List<Account> accounts = await accountRepo.getAll();
            List<AccountDTO> accountDTOs = mapper.Map<List<AccountDTO>>(accounts);
            return accountDTOs;
        }

        public async Task banAccount(string accountId)
        {
            Account acc = await accountRepo.getOne(accountId);
            acc.IsBanned = !acc.IsBanned;
            await accountRepo.update(acc);
        }

        public async Task<AccountDTO> getAccountById(string accountId) { 
            Account acc = await accountRepo.getOne(accountId);
            AccountDTO accountDTO = mapper.Map<AccountDTO>(acc);
            return accountDTO;
        }

        public async Task<string> checkPassword(string accountId, string inputPass)
        {
            Account acc = await accountRepo.getOne(accountId);

            if (acc != null&& acc.HashPassword.Equals(inputPass))
            {
                return "correct";
            }

            return "uncorrect";
        }

        public async Task editAccount (AccountDTO accountDTO)
        {
            Account acc = mapper.Map<Account>(accountDTO);
            await accountRepo.update(acc);
        }

        public async Task<string> editPassword (string accountId, string oldpasswod, string newpassword)
        {
            return await accountRepo.editPassword(accountId, oldpasswod, newpassword);
        }
    }
}
