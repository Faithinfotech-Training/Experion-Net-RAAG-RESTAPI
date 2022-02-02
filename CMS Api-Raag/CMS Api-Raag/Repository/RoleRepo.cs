using CMS_Api_Raag.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
    public class RoleRepo : IRoleRepo
    {
        private readonly CMSDBContext _context;
        public RoleRepo(CMSDBContext context)
        {
            _context = context;
        }

        //viewing all roles
        public async Task<List<Role>> GetRoles()
        {
            if (_context != null)
            {
                return await _context.Role.Include(e => e.Employee).ToListAsync();
            }
            return null;
        }
    }
}
