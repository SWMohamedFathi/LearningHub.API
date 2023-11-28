using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Repoistory;
using LearningHub.Core.Service;
using LearningHub.Infra.Repoistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Service
{
    public class CourseService: ICourseService
    {

        private readonly ICourseRepoistory CourseRepoistory;

        public CourseService(ICourseRepoistory courseRepository)
        {
            this.CourseRepoistory = courseRepository;
        }

        public List<Course> GetAllCourse()
        {
            return CourseRepoistory.GetAllCourses();
        }


        public void CreateCourse(Course course)
        {
            CourseRepoistory.CreateCourse(course);
        }
        public void UpdateCourse(Course course)
        {
            CourseRepoistory.UpdateCourse(course);
        }

        public void DeleteCourse(int id)
        {
            CourseRepoistory.DeleteCourse(id);
        }


        public Course GetCourseById(int id)
        {
            return CourseRepoistory.GetCourseById(id);
        }

        public List<UserDTO>getuserRole()
        {
           return  CourseRepoistory.getuserRole();
        }

        public List<Search> filter(Search search)
        {
            return CourseRepoistory.filter(search);
        }

        public Task<List<Category>> GetAllCategoryCourse()
        {
            return CourseRepoistory.GetAllCategoryCourse();
        }


    }
}
