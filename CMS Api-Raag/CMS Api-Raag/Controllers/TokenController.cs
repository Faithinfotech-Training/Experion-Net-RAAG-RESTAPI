using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Api_Raag.Models;
using CMS_Api_Raag.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Api_Raag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenRepository _tokenRepository;

        //constructor injection
        public TokenController(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        #region Get All Token
        //EndPoint :- https://localhost:44343/api/token
        [HttpGet]
        //  [Authorize]
        //  [Authorize(AuthenticationSchemes ="Bearer")] 
        public async Task<ActionResult<IEnumerable<Token>>> GetAllToken()
        {
            return await _tokenRepository.GetAllTokens();
        }

        #endregion

        #region Add Token
        //EndPoint :- https://localhost:44343/api/token
        [HttpPost]
        public async Task<IActionResult> AddToken([FromBody] Token token)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var tokenId = await _tokenRepository.AddToken(token);
                    if (tokenId > 0)
                    {
                        return Ok(tokenId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion
    }
}
