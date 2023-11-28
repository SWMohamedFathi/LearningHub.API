using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Service
{
    public interface ICourseService
    {
        List<Course> GetAllCourse();
        void CreateCourse(Course course);
        void DeleteCourse(int id);
        public void UpdateCourse(Course course);
        Course GetCourseById(int id);
        public List<UserDTO> getuserRole();
        public List<Search> filter(Search search);
        Task<List<Category>> GetAllCategoryCourse();


    }
}
