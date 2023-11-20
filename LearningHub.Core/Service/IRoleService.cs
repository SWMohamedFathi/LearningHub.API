using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Service
{
    public interface IRoleService
    {
        List<Role> GetAllRoles();
        void CreateRole(Role role);
        Role GetRoleById(int id);
        void UpdateRole(Role role);
        void DeleteRole(int id);




    }
}
