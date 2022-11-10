using System;
using SampleCore.Core.IRepositories;
using SampleCore.Core.IServices;
using SampleCore.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCore.Service.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _studentRepository;

        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void CreateStudentEntry(Student student)
        {
            //business condition
            if (student.FirstName != string.Empty && student.FirstName != string.Empty)
            {
                _studentRepository.CreateStudentEntry(student);
            }
        }
        public List<Student> Reads()
        {
            return _studentRepository.Reads();
        }
        public Student EditForm(int id)
        {
            return _studentRepository.EditForm(id);

        }
        public void Delete(int student_id)
        {
            _studentRepository.Delete(student_id);
        }
    }
}
