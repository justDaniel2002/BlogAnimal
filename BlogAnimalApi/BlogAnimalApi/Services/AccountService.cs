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
    }
}
