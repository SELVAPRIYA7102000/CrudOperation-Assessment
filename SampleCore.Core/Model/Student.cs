using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCore.Core.Model
{
    public class Student
    {

        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string department { get; set; }
        public int age { get; set; }
        public string Class { get; set; }
        public string Gender { get; set; }
        public DateTime JoiningYear { get; set; }
        public string joining { get; set; }
        public string Mobile { get; set; }
        public string? Location { get; set; }
      
        public bool Is_Deleted { get; set; }
        public DateTime Created_Time_Stamp { get; set; }
        public DateTime Updated_Time_Stamp { get; set; }
    }
}
