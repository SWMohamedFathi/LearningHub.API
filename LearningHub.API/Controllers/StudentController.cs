using LearningHub.Core.Data;
using LearningHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService;
        }



        [HttpGet]
        [Route("GetAllStudent")]
       public List<Student> GetAllStudent()
        {
            return _studentService.GetAllStudent();
        }
        [HttpGet]
        [Route("GetStudentById/{id}")]
        public  Student GetStudentById(int id)
        {
          return  _studentService.GetStudentById(id); 
        }

        [HttpPost]
        [Route("CreateStudent")]
     public void CreateStudent(Student Student)

        {
            _studentService.CreateStudent(Student);
        }

        [HttpPut]
        [Route("UpdateStudent")]

        public void UpdateStudent(Student Student) 
        { 
        _studentService.UpdateStudent(Student);
        
        }
        [HttpDelete]

        [Route("DeleteStudent/{id}")]

        public void DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
        }


    }











}

