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
    public class StudentCourseService : IStudentCourseService
    {

        private readonly IStudentCourseRepository _studentCourseRepoistory;

        public StudentCourseService(IStudentCourseRepository studentCourseRepoistory)
        {
            _studentCourseRepoistory = studentCourseRepoistory;
        }


        public void CreateStudentCourse(Stdcourse studentCourse)
        {
            _studentCourseRepoistory.CreateStudentCourse(studentCourse);
        }
        public void DeleteStudentCourse(int id)
        {
            _studentCourseRepoistory.DeleteStudentCourse(id);
        }

        public List<Stdcourse> GetAllStudentCourse()
        {
            return _studentCourseRepoistory.GetAllStudentCourse();
        }

        public void UpdateStudentCourse(Stdcourse studentCourse)
        {
            _studentCourseRepoistory.UpdateStudentCourse(studentCourse);
        }

        public Stdcourse GetStudentCourseById(int id)
        {
            return _studentCourseRepoistory.GetStudentCourseById(id);
        }



    }
}
