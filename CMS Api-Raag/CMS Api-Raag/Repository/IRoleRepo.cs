using CMS_Api_Raag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
    public interface IRoleRepo
    {

        //View Roles
        Task<List<Role>> GetRoles();
    }
}
