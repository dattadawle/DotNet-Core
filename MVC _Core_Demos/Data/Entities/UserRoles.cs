﻿public class UserRoles
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public User User { get; set; }  
    public Role Roles { get; set; }

}
