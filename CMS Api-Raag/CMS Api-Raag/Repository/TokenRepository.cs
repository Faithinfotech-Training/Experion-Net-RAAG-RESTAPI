using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Api_Raag.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS_Api_Raag.Repository
{
    public class TokenRepository : ITokenRepository
    {
        //data fields
        private readonly CMSDBContext _context;

        //default constructor
        //constructor based dependency injection
        public TokenRepository(CMSDBContext context)
        {
            _context = context;
        }

        //Implement the interface

        //Method to get all Token
        #region Get All Token
        public async Task<List<Token>> GetAllTokens()
        {
            if (_context != null)
            {
                return await _context.Token.ToListAsync();
            }
            return null;
        }

        #endregion

        //Method to add a new Token
        #region Add Token
        public async Task<int> AddToken(Token token)
        {
            if (_context != null)
            {
                await _context.Token.AddAsync(token);
                await _context.SaveChangesAsync();
                return token.TokenNo;
            }
            return 0;
        }
        #endregion

    }
}
