using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    internal class StudentValidation
    {
        public Student GetStudentDataByUser(User user)
        {
            StudentData studentData = new StudentData();
           if(user == null || user.fakName == null)
            {
                throw new ArgumentNullException("No faculty number in this user");
            } 

           IEnumerable<Student> list = studentData.GetStudents();

           foreach(Student st in list)
            {
                if (st.FacultyNumber.Equals(user.fakName))
                {
                    return st;
                }
            }

            throw new ArgumentNullException("No such student");

        }
    }
}
