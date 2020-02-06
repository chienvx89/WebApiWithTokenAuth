using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWithTokenAuth.Libraries
{
    public static class TokenLifetimeValidator
    {
        public static bool Validate(
                DateTime? notBefore,
        DateTime? expires,
        SecurityToken tokenToValidate,
        TokenValidationParameters @param
    )
        {
            var kq = (expires != null && expires > DateTime.UtcNow);
            return kq;
        }
    }
}
