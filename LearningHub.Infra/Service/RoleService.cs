using LearningHub.Core.Data;
using LearningHub.Core.Repoistory;
using LearningHub.Core.Service;
using LearningHub.Infra.Repoistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository RoleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this.RoleRepository = roleRepository;
        }

        public List<Role> GetAllRoles()
        {
            return RoleRepository.GetAllRoles();
        }

        public void CreateRole(Role role)
        {

            RoleRepository.CreateRole(role);
        }


        public void UpdateRole(Role role)
        {
            RoleRepository.UpdateRole(role);

        }

        public Role GetRoleById(int id)
        {

            return RoleRepository.GetRoleById(id);
        }

        public void DeleteRole(int id)
        {
            RoleRepository.DeleteRole(id);
        }

    }
}
