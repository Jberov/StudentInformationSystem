using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public int ID { get; set; }
        public string StudentName { get; set; }
        public string? FatherName { get; set; }
        public string FamilyName { get; set; }
        public string Specialty { get; set; }
        public string? Education { get; set; }
        public string? StudentStatus { get; set; }
        public string FacultyNumber { get; set; }
        public int? StudentYear { get; set; }
        public int Class { get; set; }
        public int StudentGroup { get; set; }

    }
}
