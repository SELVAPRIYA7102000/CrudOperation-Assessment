using SampleCore.Core.IRepositories;
using SampleCore.Core.Model;
using SampleCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCore.Repositories.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public StudentCredentialsContext entity;
        public StudentRepository(StudentCredentialsContext studentDetailsContext)
        {
            entity = studentDetailsContext;
        }

        #region create
        public void CreateStudentEntry(Core.Model.Student student)
        {

            if (student.StudentID == 0)
            {

                SampleCore.Entity.Student_Details student1 = new SampleCore.Entity.Student_Details();


                student1.Student_ID = student.StudentID;
                student1.First_Name = student.FirstName;
                student1.Last_Name = student.LastName;
                student1.Department = student.department;
                student1.Gender = student.Gender;
                student1.Phone = student.Mobile;
                student1.Year_Of_Joining = DateTime.Parse(student.joining);
                student1.Class = student.Class;
                student1.Age = student.age;
                student1.Location = student.Location;
                
                student1.Is_Deleted = student.Is_Deleted;
                student1.Created_Time_Stamp = DateTime.Now;
                student1.Updated_Time_Stamp = DateTime.Now;
                entity.Add(student1);
                entity.SaveChanges();

            }
            else
            {
                var data = entity.Student_Details.Where(x => x.Student_ID == student.StudentID).SingleOrDefault();


                    data.First_Name = student.FirstName;
                    data.Last_Name = student.LastName;
                    data.Gender = student.Gender;
                    data.Age = student.age;
                    data.Department = student.department;
                    data.Class = student.Class;
                    data.Phone = student.Mobile;
                    data.Location= student.Location;
                   
                    data.Is_Deleted = student.Is_Deleted;
                    data.Created_Time_Stamp = DateTime.Now;
                    data.Updated_Time_Stamp = DateTime.Now;

                    data.Year_Of_Joining = DateTime.Parse(student.joining);

                    entity.SaveChanges();

             }

        }

        #endregion
        #region Edit
        public Student EditForm(int id)
        {
            Student pr = new Student();
            var data = entity.Student_Details.Where(x => x.Student_ID == id).SingleOrDefault();
           

            
            pr.joining = data.Year_Of_Joining.ToString("yyyy-MM-dd");
            pr.StudentID = data.Student_ID;
            pr.FirstName = data.First_Name.Trim();
            pr.LastName = data.Last_Name.Trim();
            pr.Gender = data.Gender;
            pr.age = data.Age;
            pr.department = data.Department;
            pr.Class=data.Class;
            pr.Mobile = data.Phone;
            pr.Location = data.Location;
           
           
            return pr;
        }


        #endregion

        #region Read
        public List<Student> Reads()
        {
            List<Student> Model = new List<Student>();
            var Student_Db = entity.Student_Details.Where(x => !x.Is_Deleted).ToList();
           
                foreach (var item in Student_Db)
                {
                    Student employeeModel = new Student();
                    employeeModel.StudentID = item.Student_ID;
                     employeeModel.FirstName = item.First_Name;
                    employeeModel.Class = item.Class;
                   employeeModel.LastName = item.Last_Name;
                    employeeModel.Location = item.Location;
                    employeeModel.age = item.Age;
                    employeeModel.department = item.Department;
                    employeeModel.Gender = item.Gender;
                    employeeModel.Mobile = item.Phone;
                    employeeModel.JoiningYear = item.Year_Of_Joining;
                    
                employeeModel.joining = item.Year_Of_Joining.ToString("yyyy-MM-dd");
                   
                    Model.Add(employeeModel);
                }
            
            return Model;
        }
        #endregion


        #region Delete
        public void Delete(int student_id)
        {
            var data = entity.Student_Details.Where(x => x.Student_ID == student_id).SingleOrDefault();
            data.Is_Deleted = true;
            entity.SaveChanges();
        }

        #endregion
    }
}

