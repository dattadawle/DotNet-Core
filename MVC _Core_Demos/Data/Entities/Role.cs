﻿using Microsoft.Identity.Client;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<UserRoles> userRoles { get; set; }

}