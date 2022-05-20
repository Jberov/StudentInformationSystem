using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UserLogin;
namespace StudentInfoSystem
{
    public class LoginCommand : ICommand
    {

        private LoginWindow _loginWindow = new LoginWindow();
       
        public void Execute(object sender)
        {
            if (CanExecute(sender))
            {
                MainWindow main = new MainWindow();
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid login");
            }
        }

        public bool CanExecute(object sender)
        { 
            UserData.resetUserData();
            LoginValidation.ActionOnError errHandler = DeclareError;
            string username, password;
            username = _loginWindow.usernameBox.Text;
            password = _loginWindow.passwordBox.Text;
            User user = new User();
            LoginValidation loginValidation = new LoginValidation(username,password,errHandler);
            return loginValidation.validateUserInput(ref user);
        } 
        public event EventHandler CanExecuteChanged;
        public static void DeclareError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
            Logger.LogLoginError(errorMessage);
        }
    }
}
