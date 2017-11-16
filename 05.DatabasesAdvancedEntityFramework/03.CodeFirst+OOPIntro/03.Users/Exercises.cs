using _03.Users;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var context = new UsersContext();

        Users user=new Users()
        {
            Username = "UserX",

            Password = "BloodyComplexP455w0rd##",

            eMail = "just@some.em",

            RegisteredOn = new DateTime(2003, 10, 10),

            LastTimeLoggedIn = new DateTime(2016, 10, 10),

            Age = 101,

            IsDeleted = false
        };

        context.SaveChangesAsync();
    }
}