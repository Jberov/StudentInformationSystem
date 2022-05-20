using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Expenselt
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {
        public List<Person> ExpenseDataSource {get; set; }
        public string MainCaptionText { get; set; }
        private DateTime _lastChecked;
        public DateTime LastChecked {
            get { return _lastChecked; }
            set { _lastChecked = value; }
        }
        public ObservableCollection<string> PersonsChecked
        {
            get; set;
        }



        public ExpenseItHome()
        {
            InitializeComponent();
            PersonsChecked = new ObservableCollection<string>();

            ExpenseDataSource = new List<Person>()
            {
            new Person()
            {
            Name="Mike",
            Department ="Legal",
            Expenses = new List<Expense>()
            {
            new Expense() { ExpenseType="Lunch", ExpenseAmount =50 },
            new Expense() { ExpenseType="Transportation", ExpenseAmount=50 }
            }
            },
            new Person()
            {
            Name ="Lisa",
            Department ="Marketing",
            Expenses = new List<Expense>()
            {
            new Expense() { ExpenseType="Document printing", ExpenseAmount=50 },
            new Expense() { ExpenseType="Gift", ExpenseAmount=125 }
            }
            },
            new Person()
            {
            Name="John",
            Department ="Engineering",
            Expenses = new List<Expense>()

            {
            new Expense() { ExpenseType="Magazine subscription", ExpenseAmount=50 },
            new Expense() { ExpenseType="New machine", ExpenseAmount=600 },
            new Expense() { ExpenseType="Software", ExpenseAmount=500 }
            }
            },
            new Person()
            {
            Name="Mary",
            Department ="Finance",
            Expenses = new List<Expense>()
            {
            new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
            }
            },
            new Person()
            {
            Name="Theo",
            Department ="Marketing",
            Expenses = new List<Expense>()
            {
            new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
            }
            },
            new Person()
                {
                Name="David",
                Department ="IT",
                Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                    }
                },
                new Person()
                {
                    Name="John",
                    Department ="Engineering",
                    Expenses = new List<Expense>()

                    {
                        new Expense() { ExpenseType="Magazine subscription", ExpenseAmount=50 },
                        new Expense() { ExpenseType="New machine", ExpenseAmount=600 },
                        new Expense() { ExpenseType="Software", ExpenseAmount=500 }
                    }
                }
            };
            MainCaptionText = "View Expense Report :";
            LastChecked = DateTime.Now;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if(MessageBox.Show("ExpenseIt","Open report?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ExpenseReport expenseReport = new ExpenseReport(peopleListBox.SelectedItem);
                expenseReport.Width = Width;
                expenseReport.Height = Height;
                expenseReport.Show();
                this.Close();
            }
            else
            {
                this.Show();
            }


        }
        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
            PersonsChecked.Add((peopleListBox.SelectedItem as System.Xml.XmlElement).Attributes["Name"].Value);
            LastChecked = DateTime.Now;
        }
    }
}
