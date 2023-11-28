using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repoistory
{
    public interface ICourseRepoistory
    {

        List<Course> GetAllCourses();
        Course GetCourseById(int id);
        void CreateCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);

        public List<UserDTO> getuserRole();
        public List<Search> filter(Search search);


        Task<List<Category>> GetAllCategoryCourse();


    }
}
