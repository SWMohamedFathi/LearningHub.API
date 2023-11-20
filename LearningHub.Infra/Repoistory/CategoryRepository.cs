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
    public class CategoryRepository : ICategoryRepository
    {
        //Instance == inject to IDbContext

        private readonly IDbContext dbContext;

        public CategoryRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }


        public List<Category> GetAllCategories()
        {
            IEnumerable<Category> result = dbContext.Connection.Query<Category>("category_Package.GetAllCategories", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }


        public void CreateCategory(Category category)
        {
            var p = new DynamicParameters();

            p.Add("categoryName", category.Categoryname, dbType :DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("category_Package.CreateCategory", p, commandType: CommandType.StoredProcedure);

        }



        public void UpdateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("categoryId", category.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("categoryName", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("category_Package.UpdateCategory", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCategory(int categoryId)
        {
            var p = new DynamicParameters();
            p.Add("categoryId", categoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("category_Package.DeleteCategory", p, commandType: CommandType.StoredProcedure);
        }

        public Category GetCategoryById(int categoryId)
        {
            var p = new DynamicParameters();
            p.Add("categoryId", categoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Category> result = dbContext.Connection.Query<Category>("category_Package.GetCategoryById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }





    }
}
