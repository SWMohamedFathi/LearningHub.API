using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repoistory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Repoistory
{
    public class RoleRepository: IRoleRepository
    {
        private readonly IDbContext dbContext;

        public RoleRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Role> GetAllRoles()
        {
            IEnumerable<Role> result = dbContext.Connection.Query<Role>("role_Package.GetAllRoles", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("roleName", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("role_Package.CreateRole", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("roleId", role.Roledid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("roleName", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("role_Package.UpdateRole", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteRole(int roleId)
        {
            var p = new DynamicParameters();
            p.Add("roleId", roleId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("role_Package.DeleteRole", p, commandType: CommandType.StoredProcedure);
        }

        public Role GetRoleById(int roleId)
        {
            var p = new DynamicParameters();
            p.Add("roleId", roleId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Role> result = dbContext.Connection.Query<Role>("role_Package.GetRoleById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
