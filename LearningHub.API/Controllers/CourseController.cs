using LearningHub.Core.Data;
using LearningHub.Core.DTO;
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
        [HttpPost]

        [Route("uploadImage")]
        public Course UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Course item = new Course();
            item.Imagename = fileName;
            return item;
        }
        [HttpGet]
        [Route("getuserRole")]

        public List<UserDTO> getuserRole()
        {
            return courseService.getuserRole();
        }

        [HttpPost]
        [Route("filter")]
        public List<Search> filter(Search search)
        {
            return courseService.filter(search);
        }


        [HttpGet]
        [Route("getallcategory")]
        [HttpGet]
        [Route("GetAllCategoryCourse")]
        public Task<List<Category>> GetAllCategoryCourse()
        {
            return courseService.GetAllCategoryCourse();

        }

    }
}
