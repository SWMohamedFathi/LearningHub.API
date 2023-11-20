using LearningHub.Core.Data;
using LearningHub.Core.Service;
using LearningHub.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        [HttpGet]
        [Route("GetAllCourse")]
        public List<Course> GetAllCourse()
        {
            return courseService.GetAllCourse();
        }

        [HttpGet]
        [Route("GetCourseById/{id}")]
        public Course GetCourseById(int id)
        {
            return courseService.GetCourseById(id);

        }

        [HttpPost]
        [Route("CreateCourse")]

        public void CreateCourse(Course course)
        {

            courseService.CreateCourse(course);
        }


        [HttpPut]
        [Route("UpdateCourse")]

        public void UpdateCourse(Course course)
        {
            courseService.UpdateCourse(course);
        }

        [HttpDelete]
        [Route("DeleteCourse/{id}")]
        public void DeleteCourse(int id)
        {
            courseService.DeleteCourse(id);
        }

    }
}
