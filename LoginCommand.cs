using System;
using System.Windows;
using System.Windows.Input;
using UserLogin;
namespace StudentInfoSystem
{
    public class LoginCommand : ICommand
    {       
        public string password { get; set; }
        public string username { get; set; }

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
