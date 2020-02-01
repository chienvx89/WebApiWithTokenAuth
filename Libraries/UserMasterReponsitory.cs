using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithTokenAuth.FakeData;

namespace WebApiWithTokenAuth.Libraries
{
    public class UserMasterReponsitory
    {
        
        public UserMaster ValidateUser(string username, string password)
        {
            return FakeDatabase.ContextData.FirstOrDefault(user =>
            user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.UserPassword == password);
        }

    }
}
