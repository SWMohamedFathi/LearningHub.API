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
    public class StudentRepository : IStudentRepository
    {

        private readonly IDbContext dbContext;

        public StudentRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }




        public List<Student> GetAllStudent()
        {
            IEnumerable<Student> result = dbContext.Connection.Query<Student>("Student_Package.GetAllStudent", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateStudent(Student Student)
        {
            var p = new DynamicParameters();
            p.Add("first_name", Student.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("last_name", Student.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);

            p.Add("date_of_birth", Student.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("Student_Package.CreateStudent", p, commandType: CommandType.StoredProcedure);


        }


        public void UpdateStudent(Student Student)
        {
            var p = new DynamicParameters();
            p.Add("ID", Student.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("first_name", Student.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("last_name", Student.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("date_of_birth", Student.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("Student_Package.UpdateStudent", p, commandType: CommandType.StoredProcedure);
        }



        public void DeleteStudent(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("Student_Package.DeleteStudent", p, commandType: CommandType.StoredProcedure);
        }


        public Student GetStudentById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Student> result = dbContext.Connection.Query<Student>("Student_Package.GetStudentById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }










    }
}