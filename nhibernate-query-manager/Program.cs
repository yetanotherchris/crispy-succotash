using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using NHibernate.Criterion;

namespace NHibernateQueryHelper
{
	class Program
	{
		/// <summary>
		/// CHANGE THE app.config FILE FIRST!
		/// Unit test to come.
		/// </summary>
		static void Main(string[] args)
		{
			// Example usage
			NHibernateQueryManager manager = new NHibernateQueryManager(true);
			
			// Number of User objects
            long count = manager.Count<User>();

			// First one back
            User name = manager.First<User>();

			// Get one by id
            name = manager.Read<User>(new Guid("88633368-b8e8-4303-8455-00028612c338"));

			// All items
            IList<User> list = manager.List<User>();

			// All items filtered (using AND)
            list = manager.List<User>("@Name", "54321", "@Id", new Guid("88633368-b8e8-4303-8455-00028612c338"));

			// All items filtered (using OR)
            list = manager.OrList<User>("@Name", "12345", "@Name", "54321");

			// All items, sorted
            list = manager.OrderedList<User>("Name");

			// Paged
            list = manager.Page<User>(1, 10);

			// Criteria example
            list = manager.List<User>(Expression.Like("Name", "12%"));

			// HQL example
            list = manager.Query<User>("FROM User WHERE Name = '12345'");

			// Save,Delete examples are self explanatory
		}
	}



	public class User
	{
		public User()
		{
		}


		/// <summary>
		/// Gets/sets the Id.
		/// </summary>
		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}

		/// <summary>
		/// Gets/sets the Name.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _name;
		private Guid _id;
	}
}
