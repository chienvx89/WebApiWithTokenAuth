using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWithTokenAuth.FakeData
{
    public static class FakeDatabase
    {
        public static IEnumerable<UserMaster> ContextData = new List<UserMaster> {
                new UserMaster{UserId = 1,UserName ="Alice", UserEmailId="Alice@gmail.com",UserPassword="12345",UserRole ="Admin" },
                new UserMaster{UserId = 2,UserName ="Alice02", UserEmailId="Alice02@gmail.com",UserPassword="12345",UserRole ="Admin" },
                new UserMaster{UserId = 3,UserName ="Alice03", UserEmailId="Alice03@gmail.com",UserPassword="12345",UserRole ="User" },
                new UserMaster{UserId = 4,UserName ="Alice04", UserEmailId="Alice04@gmail.com",UserPassword="12345",UserRole ="User" },
                new UserMaster{UserId = 5,UserName ="Alice05", UserEmailId="Alice05@gmail.com",UserPassword="12345",UserRole ="User" },
                new UserMaster{UserId = 6,UserName ="Alice06", UserEmailId="Alice06@gmail.com",UserPassword="12345",UserRole ="User" },
                new UserMaster{UserId = 7,UserName ="Alice07", UserEmailId="Alice07@gmail.com",UserPassword="12345",UserRole ="User" },
            };
       
    }
}
