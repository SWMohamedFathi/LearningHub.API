using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Repoistory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Repoistory
{
    public class CourseRepoistory : ICourseRepoistory
    {
        //Instance == inject to IDbContext

        private readonly IDbContext dbContext;

        public CourseRepoistory(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        //get all courses == list<Course>

        public List<Course> GetAllCourses()
        {

            IEnumerable<Course> result = dbContext.Connection.Query<Course>("Course_Package.GetAllCourses", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }



        public void CreateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("COURSENAME", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CATID", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("image", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Course_Package.CREATECOURSE", p, commandType: CommandType.StoredProcedure);


        }

        public void UpdateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("ID", course.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CNAME", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CATID", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("image", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Course_Package.UPDATECOURSE", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Course_Package.DeleteCourse", p, commandType: CommandType.StoredProcedure);
        }




        public Course GetCourseById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Course> result = dbContext.Connection.Query<Course>("Course_Package.GetCourseById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }



        public List<UserDTO> getuserRole()
        {
            var result = dbContext.Connection.Query<UserDTO>("Course_Package.getusernamerolename", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

      

        public List<Search> filter(Search search)
        {
            var p = new DynamicParameters();
            p.Add("cName", search.Coursename, DbType.String, ParameterDirection.Input);
            p.Add("sName", search.Firstname, DbType.String, ParameterDirection.Input);
            p.Add("DateFrom", search.DateFrom, DbType.Date, ParameterDirection.Input);
            p.Add("DateTo", search.DateTo, DbType.Date, ParameterDirection.Input);

            var result = dbContext.Connection.Query<Search>("stdcourse_Package.SearchStudentAndCourse",
                p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Category>> GetAllCategoryCourse()
        {


            var result1 = await dbContext.Connection.QueryAsync<Category, Course, Category>("Course_Package.GetAllCategoryCourse", (Category, course) =>
            {
                Category.Courses.Add(course);
                return Category;
            },
          splitOn: "Courseid",
            param: null,
            commandType: CommandType.StoredProcedure

            );
            //result1 =
            /*
                  1 - Backend ==> 1 - C#
                  1 - Backend ==> 2 - c++
                  1 - Backend ==> 3 - API
                  2 - FrontEnd ==> 5 - html
                  2 - frontend ==> 4 - c++
                  2 - frontend ==> 6 - API
 
                 */
            var results2 = result1.GroupBy(p => p.Categoryid).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.Courses = g.Select(p => p.Courses.Single()).ToList();
                return groupedPost;
            });
            return results2.ToList();
            //result2 =
            /*
                  1 - Backend ==> 
                    1 - C#
                    2 - c++
                    3 - API
                  2 - FrontEnd ==> 
                    5 - html
                    4 - c++
                    6 - API
 
                 */
        }



    }
}