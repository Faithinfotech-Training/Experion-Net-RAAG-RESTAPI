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

namespace CMS_Api_Raag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        CMSDBContext DB = new CMSDBContext();
        [Route("Login")]
        [HttpPost]
        public ResponseViewModel employeeLogin(LoginViewModel login)
        {
            var log = DB.Employee.Where(x => x.EmailAddress.Equals(login.EmailAddress) &&
                      x.Password.Equals(login.Password)).FirstOrDefault();

            if (log == null)
            {
                return new ResponseViewModel { Status = "Invalid", Message = "Invalid User." };
            }
            else
                return new ResponseViewModel { Status = "Success", Message = "Login Successfully" };
        }
    }
}
