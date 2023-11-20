using LearningHub.Core.Data;
using LearningHub.Core.Repoistory;
using LearningHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<Student> GetAllStudent()
        {
            return _studentRepository.GetAllStudent();
        }
        public void CreateStudent(Student Student)
        {
            _studentRepository.CreateStudent(Student);
        }

        public void UpdateStudent(Student Student)
        {
            _studentRepository.UpdateStudent(Student);
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }
        public Student GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }


    }
}
