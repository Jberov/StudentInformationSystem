using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal class StudentData
    {
        public static List<Student> TestStudents;

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



        public Student exampleStudent()
        {

            StudentInfoContext context = new StudentInfoContext();
            Student student = isStudentThere("501219042");
            return student;
        }

        public void copyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in TestStudents)
            {
                context.Students.Add(st);
                context.SaveChanges();
            }
        }

        public Student isStudentThere(string FacultyNumber)
        {
         StudentInfoContext context = new StudentInfoContext();

         Student result =
         (from st in context.Students
                where st.FacultyNumber == FacultyNumber
          select st).First();

          return result;
        }

        public void deleteStudent(string FacultyNumber)
        {
            StudentInfoContext context = new StudentInfoContext();
            Student delObj =
            (from st in context.Students
             where st.FacultyNumber == FacultyNumber
             select st).First();
            context.Students.Remove(delObj);
            context.SaveChanges();
        }
        private static List<Student> GetRegions()
        {
            StudentInfoContext context = new StudentInfoContext();
            List<Student> students = context.Students.ToList();
            return students;
        }

    }
}
