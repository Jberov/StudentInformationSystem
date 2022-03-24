using System;

namespace UserLogin
{
	public class User
	{
		private String _username;
		public String username
        {
            get; set; 
        }
		private String _password;
		public String password
		{
			get;set;
		}
		private String _fakName;
		public String fakName
		{
			get; set;
		}
		private UserRole _role;
		public UserRole role
		{
			get; set;
		}

		public DateTime Created;

		public User()
		{

		}
	}
}
