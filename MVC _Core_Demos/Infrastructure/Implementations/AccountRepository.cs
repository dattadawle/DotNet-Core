using Data;
using System.Collections.Immutable;

public class AccountRepository : IAccountRepository
{

    private readonly ApplicationDbContext _context;
    public AccountRepository( ApplicationDbContext context )
    {
        _context = context;
        
    }
    public bool Login(string email, string password, out string roleName)
    {
    bool isExist =    _context.users.Any(u=> u.Email==email &&  u.Password==password);

        if (isExist)
        {
            roleName = (from u in _context.users
                        join ur in _context.userRoles
                        on u.id equals ur.UserId
                        join r in _context.roles
                        on ur.RoleId equals r.Id
                        where u.Email == email && u.Password == password
                        select r.Name)?.FirstOrDefault();
        }
        else
        {
            roleName = " ";
        }
        return isExist;
    }




    // Register

    public async Task< bool >Register(User user)
    {
       _context.users.Add(user);
    var numberOfUserAdded =  await _context.SaveChangesAsync();

        _context.userRoles.Add(new UserRoles() { UserId= user.id,RoleId =2 });
    var numberOfUserRoleAdded  = await _context.SaveChangesAsync(); 
        return numberOfUserAdded>0 && numberOfUserRoleAdded > 0;
    }
}