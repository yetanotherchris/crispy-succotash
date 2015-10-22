using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;


namespace Mia.Core
{
	public class Log
	{
		public Guid Id { get; set; }
		public DateTime CreateDate { get; set; }
		public string Text { get; set; }
		public LogType Type { get; set; }

		public static void Information(string message, params object[] args)
		{
			Log log = new Log()
			{
				Id = Guid.NewGuid(),
				CreateDate = DateTime.Now,
				Text = string.Format(message, args),
				Type = LogType.Information
			};

			using (DbConnection connection = Db.CreateConnection())
			{
				connection.Open();
				connection.Insert<Log>(log);
				Console.WriteLine(log.Text);
			}

			//EventLog.WriteEntry("Mia", string.Format(message, args), EventLogEntryType.Information);
		}

		public static void Error(string message, params object[] args)
		{
			Log log = new Log()
			{
				Id = Guid.NewGuid(),
				CreateDate = DateTime.Now,
				Text = string.Format(message, args),
				Type = LogType.Error
			};

			using (DbConnection connection = Db.CreateConnection())
			{
				connection.Open();
				connection.Insert<Log>(log);
				Console.WriteLine(log.Text);
			}

			//EventLog.WriteEntry("Mia", string.Format(message, args), EventLogEntryType.Error);
		}
	}
}
