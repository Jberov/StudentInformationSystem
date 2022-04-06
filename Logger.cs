using System;
using System.IO;
using System.Text;

namespace UserLogin
{
	public class Logger
	{
		static private List<string> currentSessionActivities = new List<string>();

		public Logger()
		{

		}

		static public void LogActivity(string activity)
		{
			string activityLine = DateTime.Now + ","
				+ LoginValidation.username + ","
				+ LoginValidation.getRole() + ","
				+ activity + "\r\n";

			if (File.Exists("test.txt"))
            {
				Thread.Sleep(1000);
				File.AppendAllText("test.txt", activityLine);
            }
			currentSessionActivities.Add(activityLine);
		}

		public static void LogLoginError(string message)
        {
			string errorLine = DateTime.Now + "," + "Error logging in, " + message + "\r\n";
            if (!File.Exists("error.txt"))
            {
				FileStream file = File.Create("error.txt");
				StreamWriter writer = new StreamWriter(file);
				writer.WriteLine(message);
				writer.Close();
				file.Close();
            }
            else
            {
				File.AppendAllText("error.txt", errorLine);
            }			
		}

		static public IEnumerable<string> GetAllLinesFromFile()
        {
			List<string> lines = new List<string>();
			StreamReader reader = new StreamReader("test.txt");
			while (reader.Peek() >= 0)
			{
				lines.Add(reader.ReadLine());
			}
			reader.Close();
			return lines;
		}

		static public void VisualizeLogs()
        {
			IEnumerable<string> lines = GetAllLinesFromFile();
			foreach (string line in lines)
            {
				Console.WriteLine(line);
            }
        }

		public static IEnumerable<string> GetCurrentSessionActivities(String filter)
		{
			IEnumerable<string> activityList = (from activity in currentSessionActivities where activity.Contains(filter) select activity).ToList();
			return activityList;
		}

		static public void VisualizeCurrentLogs(string filter)
        {
			StringBuilder strBuilder = new StringBuilder();
			IEnumerable<string> currentLogs = GetCurrentSessionActivities(filter);
			foreach(string line in currentLogs)
            {
				strBuilder.Append(line);
            }

			Console.WriteLine(strBuilder.ToString());
        }
		static public void CountLogs()
		{
			StreamReader reader = new StreamReader("test.txt");
			int count = 0;
			while (reader.Peek() >= 0)
			{
				Console.WriteLine(reader.ReadLine());
				count++;
			}
			reader.Close();

			Console.WriteLine("Count of logs: " + count);
		}

		public static void OldestLog()
        {
			StreamReader reader = new StreamReader("test.txt");
			string log = reader.ReadLine();
			reader.Close();

			Console.WriteLine("Oldest log: " + log);
		}
	}
}
