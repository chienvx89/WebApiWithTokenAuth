using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApiWithTokenAuth.Libraries
{
    public static class AuthenServices
    {
        public static string GetTokenString()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            
            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:5001",
                audience: "http://localhost:5001",
                claims: new List<Claim>() {
                    new Claim("display-name", "Xuan Dieu"),
                     new Claim("permission","admin")
                },
                expires: DateTime.UtcNow.AddSeconds(20),
                
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }

        public static JwtSecurityToken ReadJwtToken(string strToken) {
            var rs = new JwtSecurityTokenHandler().ReadJwtToken(strToken);
            return rs;

        }
    }
}
