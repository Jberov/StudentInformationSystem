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

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginCommand LoginCommander
        {
            get; set;
        }
        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }


        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginCommander = new LoginCommand();
            LoginCommander.username = usernameBox.Text;
            LoginCommander.password = passwordBox.Text;
        }
    }
}
