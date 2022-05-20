using System;

namespace UserLogin
{
	public class LoginValidation
	{

		private static string _username, _password, _email;
		private static UserRole _currentUserRole;
		public static string username
		{
            get
            {
				return _username;
            }
           
		}


		public delegate void ActionOnError(string error);

		private ActionOnError _onError;

		public LoginValidation(string username, string password, ActionOnError error)
        {
			_username = username;
			_password = password;
			_onError = error;
        }

		public static UserRole currentUserRole
        {
			get;
			private set;
        }

		public static UserRole getRole()
        {
			return _currentUserRole;
        }

		
		public bool validateUserInput(ref User user)
		{
			string errorMessage;

			//user.username = _username;
			//user.password = _password;
			//UserData.testUser.username = user.username;
			//UserData.testUser.username = user.password;

			if (_username.Equals(null) || _password.Equals(null))
			{
				user.role = UserRole.ANONYMOUS;
				_onError("Null username or password");
				return false;
			}else if(IsStringEmpty(_username) || IsStringEmpty(_username))
            {
				user.role = UserRole.ANONYMOUS;
				_onError("Empty username or password");
				return false;
            }else if(IsStringLessThan5(_username) || IsStringLessThan5(_password))
            {
				user.role = UserRole.ANONYMOUS;
				_onError("Too short username or password");
				return false;
            }

			user = UserData.IsUserPassCorrect(_username, _password);

			if (user == null)
			{
				errorMessage = "No user";
				_onError(errorMessage);
				return false;
			}
			_currentUserRole = user.role;
			Logger.LogActivity("Успешен Login");
			//currentUserRole = user.role;
			return true;
		}

		

		private static bool IsStringEmpty(string word)
        {
			return word.Equals(String.Empty);
        }

		private static bool IsStringLessThan5(string word)
		{
			return word.Length < 5;
		}

		public LoginValidation()
		{
		}
	}
}
