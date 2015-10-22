##Details

This is a small class (less than 1000 lines) modelled on CoolStorage ORM's CSObject. The main goal is to get you up and running quickly with NHibernate without needing to delve into the manual.

The class offers common operations for NHibernate. It's akin to a repository pattern, without any interface specifying what it should do. The intention is to use it inside a repository rather than as a replacement for one.

Here is an example of some of the methods:

 * List
 * OrderedList
 * Read(id)
 * ReadFirst
 * Count
 * Page(page,pagesize)

Each query is performed using a pattern much like the Unit of Work one (except only one query is ever used). The ISession is by default closed and disposed of once the query is complete.

## Download 
You only need one class NHibernateQueryManager.cs.

##Example code

###Initialization
You can initialize NHibernate Query Manager in various different ways. The easiest is to have your NHibernate settings inside a hibernate.cfg.xml, and mark this file as "content" so each build copies it to your bin folder. For web applications this method removes the need to redeploy your assembly DLLs each time you change the database settings - simply recycle the app pool via a web.config change. It's one line of code to use this method:

	NHibernateManager manager = new NHibernateManager(typeof(User));


This will work where your mappings are declared in a separate assembly. If you are using NHibernate's LazyLoading for any class or collection, you can tell the manager not to dispose of the ISessions it creates:

	NHibernateManager manager = new NHibernateManager(false);

There are 5 constructor overloads giving you a set of options:

* **NHibernateQueryManager(bool disposeSessions)**  
disposeSessions : Whether sessions are disposed of before each method returns.
* **NHibernateQueryManager(Type type)**  
type : Used to load NHibernate.Configuration settings from the type's assembly.
* **NHibernateQueryManager(string idName)**  
idName: The name of the Id column for the object. This is "Id" by default.
* **NHibernateQueryManager(Dictionary<string, string> properties)**  
properties: A Dictionary with the properties to pass when building the ISessionFactory
* **NHibernateQueryManager(ISessionFactory factory, string idName)**  
Combines the two constructors above.

Sessions are disposed of by default unless you set the property, or use the constructor overload. If you want to apply your database settings without using your own SessionFactory:

	Dictionary<string,string> connection = new Dictionary<string,string>();
	connection.Add("connection.provider","NHibernate.Connection.DriverConnectionProvider");
	connection.Add("connection.driver_class","NHibernate.Driver.SqlClientDriver");
	connection.Add("connection.connection_string","server=(local);database=db;Uid=user;Pwd=Passw0rd;");
	connection.Add("dialect","NHibernate.Dialect.MsSql2005Dialect");
	connection.Add("cache.use_second_level_cache","false");

	NHibernateManager manager = new NHibernateManager(connection);


And finally if you want to use NHibernate Query Manager with Fluent NHibernate:

	// Make these thread safe singletons, see Jon Skeet's singleton pattern
	public static ISessionFactory SessionFactory;
	public static FluentConfiguration Configuration;

	void MyMethod()
	{
		Configure();
		NHibernateManager manager = new NHibernateManager(SessionFactory );
	}

	static void Configure()
	{
		Configuration = Fluently.Configure();
		Configuration.Database(MsSqlConfiguration.MsSql2008.ConnectionString("connection"));
		
		Configuration.Mappings(m => m.FluentMappings.AddFromAssemblyOf<T>());
		
		try
		{
			Configuration.BuildConfiguration();
			SessionFactory = Configuration.BuildSessionFactory();
		}
		catch (Exception e)
		{
			throw e;
		}
	}

###More general usage
You can create a NHibernateManager with one type and use other types in the lifetime of the manager object - the type passed in is simply for configuration.

	// Example usage
	NHibernateManager manager = new NHibernateManager(typeof(User));

	// Number of User objects
	long count = manager.Count<User>();

	// First one back
	User name = manager.ReadFirst<Person>();

	// Get one by id
	name = manager.Read<Contact>(new Guid("88633368-b8e8-4303-8455-00028612c338"));

	// All items
	IList<User> list = manager.List<Product>();

	// All items filtered (using AND)
	list = manager.List<User>("@Name", "54321", "@Id", new Guid("88633368-b8e8-4303-8455-00028612c338"));

	// All items filtered (using OR)
	list = manager.OrList<User>("@Name", "12345", "@Name", "54321");

	// All items, sorted
	list = manager.OrderedList<User>("Name");

	// Paged
	list = manager.Page<User>(1,10);

	// Criteria example
	list = manager.List<User>(Expression.Like("Name","12%"));

	// HQL example
	list = manager.Query<User>("FROM User WHERE Name = '12345'");

	// Save,Delete examples are self explanatory
