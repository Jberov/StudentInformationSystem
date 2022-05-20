using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal class StudentData
    {
        private List<Student> TestStudents;

        public StudentData()
        {
            TestStudents = new List<Student>();
            TestStudents.Add(exampleStudent());
        }

        public List<Student> GetStudents()
        {
            return TestStudents;
        }

        private void SetStudents(List<Student> list)
        {
            TestStudents = list;
        }

        private Student exampleStudent()
        {
            Student student = new Student();
            student.Name = "Yordan";
            student.FatherName = "Georgiev";
            student.Family = "Berov";
            student.FacultyNumber = "501219042";
            student.Year = 3;
            student.Specialty = "ITI";
            return student;
        }


    }
}
