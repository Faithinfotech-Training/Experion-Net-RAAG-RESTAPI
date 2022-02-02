using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Api_Raag.Models;

namespace CMS_Api_Raag.Repository
{
    public interface ITokenRepository
    {
        //Get all tokens       
        Task<List<Token>> GetAllTokens();

        //Add a token
        Task<int> AddToken(Token token);

    }
}
