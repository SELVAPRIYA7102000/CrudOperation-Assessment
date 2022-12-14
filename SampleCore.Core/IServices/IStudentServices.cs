using SampleCore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCore.Core.IServices
{
   public interface IStudentServices
    {
        public void CreateStudentEntry(Student student);
        public List<Student> Reads();
        public Student EditForm(int id);
        public void Delete(int student_id);
    }
}
