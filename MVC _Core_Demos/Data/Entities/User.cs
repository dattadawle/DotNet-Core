using System.Collections.ObjectModel;

public class User
{
    public int id { get; set; }
    public string Email { get; set; }

    public string Password { get; set; }

    public IEnumerable<UserRoles> UserRoles { get; set; }
}