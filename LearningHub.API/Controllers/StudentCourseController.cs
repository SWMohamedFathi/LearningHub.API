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
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseService _studentCourseService;

        public StudentCourseController(IStudentCourseService studentCourseService)
        {
            _studentCourseService = studentCourseService;
        }

        [HttpGet]
        [Route("GetAllStudentCourse")]
        public List<Stdcourse> GetAllStudentCourse()
        {
            return _studentCourseService.GetAllStudentCourse();
        }
        [HttpGet]
        [Route("GetStudentCourseById/{id}")]
        public Stdcourse GetStudentCourseById(int id)
        {
            return _studentCourseService.GetStudentCourseById(id);
        }

        [HttpPost]
        [Route("CreateStudentCourse")]
        public void CreateStudentCourse(Stdcourse stdcourse)

        {
            _studentCourseService.CreateStudentCourse(stdcourse);
        }

        [HttpPut]
        [Route("UpdateStudentCourse")]

        public void UpdateStudentCourse(Stdcourse stdcourse)
        {
            _studentCourseService.UpdateStudentCourse(stdcourse);

        }
        [HttpDelete]

        [Route("DeleteStudentCourse/{id}")]

        public void DeleteStudentCourse(int id)
        {
            _studentCourseService.DeleteStudentCourse(id);
        }

        [HttpGet]
        [Route("TotalStudentInEachCourse")]
        public List<TotalStudents> TotalStudentInEachCourse()
        {
            return _studentCourseService.TotalStudentInEachCourse();
        }

    }
}
