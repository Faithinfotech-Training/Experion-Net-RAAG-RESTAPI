using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS_Api_Raag.Models;
using CMS_Api_Raag.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CMS_Api_Raag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        //constructor injection
        public UsersController(IUserRepository userRepository, IConfiguration configuration)
        {
            _config = configuration;
            _userRepository = userRepository;
        }


        #region find a user by name and password
        //Endpoint :- https://localhost:44336/api/users/login/sarah&sarah@123
        [HttpGet("{login}/{name}&{password}")]
        public async Task<ActionResult<Employee>> GetUserByNameAndPasswords(string name, string password)
        {

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //signing credential
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            //generate token
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            expires: DateTime.Now.AddMinutes(20),
            signingCredentials: credentials);
            var response = Ok(new { token = ' ', employee = ' ' });
            if (ModelState.IsValid)
            {
                try
                {
                    var tokens = new JwtSecurityTokenHandler().WriteToken(token);
                    var emp = await _userRepository.GetUserByNameandPasswords(name, password);
                    response = Ok(new { token = tokens, UserName = emp.UserName, Password = emp.Password, RoleId = emp.RoleId,EmployeeId = emp.EmployeeId, EmployeeStatus =emp.EmployeeStatus});
                    return response;
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion


        #region Get All users  --view model

        //Endpoint :- https://localhost:44336/api/users/getallusers
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllPost()
        {
            try
            {
                var users = await _userRepository.GetAllUser();
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion
    }
}
