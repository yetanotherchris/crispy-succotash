using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;

namespace Mia.Core
{
	public class Db
	{
		private static string _connectionString;
		private static bool _testMode;

		static Db()
		{
			DapperExtensions.DapperExtensions.DefaultMapper = typeof(PluralizedAutoClassMapper<>);
			_connectionString = @"server=CORSAIR\SQLEXPRESS;database=Mia;Integrated Security=SSPI";

//#if RELEASE
			//_connectionString = @"server=mia20132.db.10181001.hostedresource.com;database=mia20132;uid=mia20132;pwd=Gr8Pencil!";
//#endif
		}

		public static void SetTestMode()
		{
			_connectionString = @"server=CORSAIR\SQLEXPRESS;database=MiaTests;Integrated Security=SSPI";
			_testMode = true;
		}

		public static void RecreateDb()
		{
			if (_testMode)
			{
				using (DbConnection connection = CreateConnection())
				{
					connection.Open();
					try
					{
						connection.Execute("DROP TABLE Quotes");
					}
					catch (SqlException) { }

					try
					{
						connection.Execute("DROP TABLE Investments");
					}
					catch (SqlException) { }

					try
					{
						connection.Execute("DROP TABLE Logs");
					}
					catch (SqlException) { }

					try
					{
						connection.Execute(GetStringFromResource("Mia.Core.Domain.create-tables.sql"));
					}
					catch (SqlException) { }
				}
			}
		}

		public static DbConnection CreateConnection()
		{
			return new SqlConnection(_connectionString);
		}

		private static string GetStringFromResource(string path)
		{
			if (string.IsNullOrEmpty(path))
				throw new ArgumentNullException("path", "The path is null or empty");

			Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
			if (stream == null)
				throw new InvalidOperationException(string.Format("Unable to find '{0}' as an embedded resource", path));

			string result = "";
			using (StreamReader reader = new StreamReader(stream))
			{
				result = reader.ReadToEnd();
			}

			return result;
		}
	}
}
