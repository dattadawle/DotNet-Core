
public class AccountService : IAccountService
{

    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
        
    }
    public bool Login(string email, string password, out string roleName)
    {
        return _accountRepository.Login(email, password, out roleName);
    }

    public Task<bool> Register(UserModel user)
    {
        return _accountRepository.Register(new User()
            {
            Email = user.Email,
            Password = user.Password,
        });
    }
}