using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApiWithTokenAuth.FakeData;
using WebApiWithTokenAuth.Libraries;

namespace WebApiWithTokenAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // GET api/values  
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid request");
            }
            string remoteIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            if (user.UserName == "chien" && user.Password == "abc@123")
            {
                string tokenString = AuthenServices.GenerateAccessToken();
                string refreshToken = AuthenServices.GenerateRefreshToken();
                FakeDatabase.ResfreshTokens.Add(refreshToken);
                return Ok(new { Token = tokenString, RefreshToken = refreshToken });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet, Route("Refresh")]
        public IActionResult RefreshToken( string token)
        {
            if (!AuthenServices.ValidateRefreshToken(token))
            {
                return BadRequest("Invalid Refresh Token");
            }

            string tokenString = AuthenServices.GenerateAccessToken();
            string refreshToken = AuthenServices.GenerateRefreshToken();

            //update refreshtoken in db
            FakeDatabase.ResfreshTokens.Remove(refreshToken);
            FakeDatabase.ResfreshTokens.Add(refreshToken);

            return Ok(new { Token = tokenString, RefreshToken = refreshToken });
        }


    }
}