using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CMS_Api_Raag.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using CMS_Api_Raag.Models;
using CMS_Api_Raag.Services;
using System.Security.Claims;
using System.Web.Http;
using CMS_Api_Raag.Repository;

namespace CMS_Api_Raag.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        //1 Dependency injection for configuration



        private readonly IConfiguration _config;
        private readonly IUserRepository _config2;



        //2 constructor injection
        public LoginController(IConfiguration config, IUserRepository config2)
        {
            _config = config;
            _config2 = config2;
        }
        //3.httpPost



        [Microsoft.AspNetCore.Mvc.HttpPost("token")]



        public async Task<IActionResult> Login([System.Web.Http.FromBody] UserModel user)
        {
            IActionResult response = Unauthorized();



            var loginUser = await AuthenticateUser(user);
            //validate and generate token
            if (loginUser != null)
            {
                var tokenString = GenerateJWToken(loginUser);
                response = Ok(new { token = tokenString, roleId = loginUser.RoleId, userName = loginUser.UserName });

            }



            return response;
        }




        //4.Authenticate user



        private async Task<UserModel> AuthenticateUser(UserModel user)
        {
            UserModel loginUser = null;
            //validate the credential
            //Retrieve datea from db
            if (user.UserName != null)
            {
                Employee userDetails = await _config2.GetUserByNameandPasswords(user.UserName, user.Password);
                loginUser = new UserModel
                {
                    UserName = userDetails.UserName,
                    RoleId = (int)userDetails.RoleId
                };
            }
            return loginUser;
        }



        //5.Generate jwt token
        private string GenerateJWToken(UserModel loginUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));



            //securitykey




            //sigiin credential

            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //claims
            //token
            var token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            expires: DateTime.Now.AddMinutes(2),
            signingCredentials: credential



            );
            return new JwtSecurityTokenHandler().WriteToken(token);



        }
    }
}
