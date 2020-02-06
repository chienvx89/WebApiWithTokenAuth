using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWithTokenAuth.FakeData
{
    public static class FakeDatabase
    {
        //In real world this get from Database
        public static IList<string> ResfreshTokens = new List<string>() { };
    }
}
