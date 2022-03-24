using System;
using System.Text;

namespace UserLogin
{
	public static class UserData
	{
		private static List<User> _testUsers = new List<User>();

		public static List<User> testUsers
		{
			get {
				resetUserData();
				return _testUsers;
			}

			set { }
		}
		public static void resetUserData() {
			if (!_testUsers.Any()) {
				_testUsers.Add(FillUser(UserRole.ADMIN));

				for (short i = 1; i < 2; i++)
				{
					_testUsers.Add(FillUser(UserRole.STUDENT));
				}
			}
		}

		public static User IsUserPassCorrect(string username, string password)
		{
			User user = (from account in testUsers where account.username.Equals(username, StringComparison.Ordinal) && account.password.Equals(password, StringComparison.Ordinal) select account).FirstOrDefault();

			return user;
		}

		public static User getUserByUsername(string username)
		{
			foreach (User user in testUsers)
			{
				if (username.Equals(user.username, StringComparison.Ordinal))
				{
					return user;
				}
			}
			return null;
		}

		private static User FillUser(UserRole role)
        {
			User user = new User();
			Console.WriteLine("Hello, please enter you username: ");
			user.username = Console.ReadLine();
			Console.WriteLine("Enter your password");
			user.password = Console.ReadLine();
			Console.WriteLine("Enter your faculty number:");
			user.fakName = Console.ReadLine();
			user.role = role;
			user.Created = DateTime.MaxValue;
			return user;
		}

		public static void SetUserActiveTo(string username, DateTime date)
        {
			foreach (User user in testUsers)
			{
				if (username.Equals(user.username, StringComparison.Ordinal))
				{
					Logger.LogActivity("Промяна на активност на " + username);
					user.Created = date;
					break;
				}
			}
		}

		public static void seeAllUsers()
        {
			foreach(User user in _testUsers)
            {
				Console.WriteLine(user.username);
            }
        }

		public static void AssignUserRole(string username, UserRole role)
		{
			foreach (User user in testUsers)
			{
				if (username.Equals(user.username, StringComparison.Ordinal))
				{
					Logger.LogActivity("Промяна на роля на " + username);
					user.role = role;
					break;
				}
			}
		}
		//TODO: Figure out how to create file, if it misses
		public static void PrepareCertificate()
        {
			StringBuilder certificateBuffer = new StringBuilder();
			certificateBuffer.AppendLine("============CERTIFICATE============");
			certificateBuffer.AppendLine();
			certificateBuffer.AppendLine("This certificate is evidence for graduating the following course and year for the following student");
			Console.WriteLine("Enter the username of the student");
			User user = getUserByUsername(Console.ReadLine());
			if(user== null)
            {
				Console.WriteLine("No such user");
				return;
            }
			certificateBuffer.AppendLine("Name: " + user.username);
			certificateBuffer.AppendLine("Faculty number: " + user.fakName);
			Console.WriteLine("Enter speciality for student");
			certificateBuffer.AppendLine("Graduated specialty: " + Console.ReadLine());
			Console.WriteLine("Enter course of the student");
			certificateBuffer.AppendLine("Course: " + Console.ReadLine());
			certificateBuffer.AppendLine();
			certificateBuffer.AppendLine("============CERTIFICATE============");
            while (true)
            {
				Console.WriteLine("Enter file name with exstension, e.g file.txt");
				string filename = Console.ReadLine();
				if((filename == null) || !filename.Contains(".txt"))
                {
					Console.WriteLine("Invalid file");
                }
                else
                {
					
					SaveCertificate(certificateBuffer.ToString(), filename);
					break;
                }
			}
			
		}

		//Figure out how to create file, if it misses
		private static void SaveCertificate(string certificate, string filename)
        {
            if (File.Exists(filename)){
				Thread.Sleep(1000);
				File.AppendAllText(filename, certificate);
            }
            else
            {
				FileStream file = File.Create(filename);
				StreamWriter writer = new StreamWriter(file);
				writer.WriteLine(certificate);
				writer.Close();
				file.Close();
			}
		}
	}
}
