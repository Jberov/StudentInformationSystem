 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> StudStatusChoices { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            FillStudStatusChoices();
            this.DataContext = this;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            CleanAllTextBoxes();
        }
        private void CleanAllTextBoxes()
        {
            foreach(Control box in grid.Children)
            {
                if(box.GetType() == typeof(TextBox))
                {
                    ((TextBox)box).Text = String.Empty;
                }
            }
        }
        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr
FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)

                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Student student = getExampleStudent();
            ShowInfo(student);
            
        }

        private void ShowInfo(Student student)
        {
            txtBoxName.Text = student.StudentName;
            txtBoxFName.Text = student.FatherName;
            txtBoxFamily.Text = student.FamilyName;
            txtBoxSpec.Text = student.Specialty;
            txtBoxFNum.Text = student.FacultyNumber;
            txtBoxClass.Text = student.Class.ToString();
            txtBoxCourse.Text = student.StudentYear.ToString();
            txtBoxClass.Text = student.Class.ToString();
            txtBoxGroup.Text = student.StudentGroup.ToString();
        }

        private Student getExampleStudent()
        {
            StudentData studentData = new StudentData();
            return studentData.GetStudents().First();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            foreach (Control box in grid.Children)
            {
                if (box.Name.Equals(btn4.Name))
                {
                    box.IsEnabled = true;
                }
                else
                {
                    box.IsEnabled = false;
                }
                foreach (Control textBox in RightGrid.Children)
                {
                    if (textBox.Name.Equals(btn4.Name))
                    {
                        textBox.IsEnabled = true;
                    }
                    else
                    {
                        textBox.IsEnabled = false;
                    }
                }
            }
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            foreach (Control box in grid.Children)
            {
                box.IsEnabled = true;
            }
        }
    }
}
