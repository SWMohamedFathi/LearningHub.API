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
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbContext dbContext;
        public LoginRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Login GenearteToken(Login login)
        {
            var p = new DynamicParameters();
            p.Add("User_NAME", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Login> result = dbContext.Connection.Query<Login>("Login_Package.User_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }
    }
}
