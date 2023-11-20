﻿using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repoistory
{
    public interface IRoleRepository
    {
        List<Role> GetAllRoles();
        void CreateRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int roleId);
        Role GetRoleById(int roleId);
    }
}
