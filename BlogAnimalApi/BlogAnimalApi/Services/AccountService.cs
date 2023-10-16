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
            AccountDTO accountDTO = mapper.Map<AccountDTO>(acc);

            return accountDTO;
        }

        public async Task SignUp(SignUpDTO accountDTO)
        {
            Account account = mapper.Map<Account>(accountDTO);
            await accountRepo.add(account);
        }
    }
}
