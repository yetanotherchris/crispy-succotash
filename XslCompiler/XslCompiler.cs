using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Schema;
using System.IO;
using System.Net;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;
using System.CodeDom.Compiler;

namespace XslTools
{
	/// <summary>
	/// Compiles single or multiple XSL files or strings into an assembly so they can be loaded into a XslCompiledTransform
	/// without it needing to compile each time.
	/// </summary>
	public class XslCompiler
	{
		#region Fields
		AssemblyBuilder _assemblyBuilder;
		#endregion

		#region Properties
		/// <summary>
		/// The folder/directory path to save the assembly in.
		/// </summary>
		public string Path { get; set; }

		/// <summary>
		/// The filename of the assembly, including ".dll". Do not include the full path.
		/// </summary>
		public string Filename { get; set; }

		/// <summary>
		/// The assembly name that is used. If this is empty, the Filename is used by default.
		/// </summary>
		public string AssemblyName { get; set; }

		/// <summary>
		/// If compiling a single XSL file, this is the classname used.
		/// </summary>
		public string Classname { get; set; }

		/// <summary>
		/// The target processor that the assembly is compiled to. This is i386 by default.
		/// </summary>
		public ImageFileMachine TargetProcessor { get; set; }

		/// <summary>
		/// Any additional XSLT settings associated with the XSL file(s).
		/// </summary>
		public XsltSettings XsltSettings { get; set; }

		/// <summary>
		/// The <see cref="XmlResolver">XmlResolver</see> used for resolving &lt;xsl:import...&gt;> statements. This is a
		/// <see cref="XmlUrlResolver">XmlUrlResolver</see> by default.
		/// </summary>
		public XmlResolver XmlResolver { get; set; }

		/// <summary>
		/// Whether to compile the XSL with the debug setting set to true. This enables debugging inside Visual Studio.
		/// This is false by default.
		/// </summary>
		public bool Debug { get; set; }

		/// <summary>
		/// Whether symbols are emitted into the assembly when it's compiled. This is false by default.
		/// </summary>
		public bool EmitSymbols { get; set; }

		/// <summary>
		/// Contains any compiler errors that occured (that weren't warnings) during the compile.
		/// </summary>
		public CompilerErrorCollection Errors { get; private set; }
		#endregion

		#region Ctor
		/// <summary>
		/// Initializes a new instance of the <see cref="XslCompiler">XslCompiler</see> class.
		/// </summary>
		public XslCompiler(string path, string assemblyFilename)
		{
			Path = path;
			Filename = assemblyFilename;
			TargetProcessor = ImageFileMachine.I386;
			XsltSettings = new XsltSettings();
			XmlResolver = new XmlUrlResolver();
			XmlResolver.Credentials = CredentialCache.DefaultCredentials;
		}
		#endregion

		#region Public methods
		/// <summary>
		/// Compiles the provided XSL file into an assembly, using the given class name.
		/// </summary>
		/// <param name="xslFilename">The fullpath to the XSL file.</param>
		/// <param name="className">The full qualified class name, e.g. MyNamespace.MyClass</param>
		/// <returns>True if the compilation was successful, false otherwise. If the compilation fails the
		/// compilation errors can be found in the <see cref="Errors">Errors</see> property.</returns>
		public bool CompileFromFile(string xslFilename, string className)
		{
			try
			{
				string xsl = File.ReadAllText(xslFilename);
				return Compile(xsl, className);
			}
			catch (IOException e)
			{
				throw new XslCompilerException(string.Format("An error occured reading from '{0}'", xslFilename), e);
			}
		}

		/// <summary>
		/// Compiles the provided XSL string into an assembly, using the given class name.
		/// </summary>
		/// <param name="xsl"></param>
		/// <param name="className">The full qualified class name, e.g. MyNamespace.MyClass</param>
		/// <returns>True if the compilation was successful, false otherwise. If the compilation fails the
		/// compilation errors can be found in the <see cref="Errors">Errors</see> property.</returns>
		public bool Compile(string xsl, string className)
		{
			if (CompileInternal(xsl, className, null))
			{
				this._assemblyBuilder.Save(Filename, PortableExecutableKinds.ILOnly, this.TargetProcessor);
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Compiles a set of XSL files from the provided list.
		/// </summary>
		/// <param name="fileList">A dictionary where the key is the classname, and the value is the filename (a fullpath).</param>
		/// <returns>True if the compilation was successful, false otherwise. If the compilation fails the
		/// compilation errors can be found in the <see cref="Errors">Errors</see> property.</returns>
		public bool CompileFromFiles(Dictionary<string, string> fileList)
		{
			try
			{
				// Default the assembly name to the filename
				if (string.IsNullOrEmpty(AssemblyName))
					AssemblyName = Filename;

				ModuleBuilder builder = this.CreateModuleBuilder(new AssemblyName(AssemblyName));

				foreach (string key in fileList.Keys)
				{
					string xsl = File.ReadAllText(fileList[key]);
					if (!CompileInternal(xsl, key, builder))
						return false;
				}

				this._assemblyBuilder.Save(Filename, PortableExecutableKinds.ILOnly, this.TargetProcessor);
				return true;
			}
			catch (IOException e)
			{
				throw new XslCompilerException("An error occured reading a file from CompileFromFiles()", e);
			}
		}

		/// <summary>
		/// Compiles a list of XSL strings using the classnames provided as keys.
		/// </summary>
		/// <param name="classList">A dictionary where the key is the classname, and the value is the XSL string.</param>
		/// <returns>True if the compilation was successful, false otherwise. If the compilation fails the
		/// compilation errors can be found in the <see cref="Errors">Errors</see> property.</returns>
		public bool CompileMultiple(Dictionary<string, string> classList)
		{
			// Default the assembly name to the filename
			if (string.IsNullOrEmpty(AssemblyName))
				AssemblyName = Filename;

			ModuleBuilder builder = this.CreateModuleBuilder(new AssemblyName(AssemblyName));

			foreach (string key in classList.Keys)
			{
				if (!CompileInternal(classList[key], key, builder))
					return false;
			}

			this._assemblyBuilder.Save(Filename, PortableExecutableKinds.ILOnly, this.TargetProcessor);
			return true;
		}

		/// <summary>
		/// Returns the compiler errors as a string in the format:
		/// Line:1 Column: 1 (123) Error text.
		/// </summary>
		/// <returns>The Errors as a string.</returns>
		public string ErrorsAsString()
		{
			StringBuilder builder = new StringBuilder();
			foreach (CompilerError error in Errors)
			{
				if (!error.IsWarning)
					builder.AppendLine(string.Format("Line:{0} Col:{1} ({2}) {3} ", error.Line, error.Column, error.ErrorNumber, error.ErrorText));
			}

			return builder.ToString();
		}
		#endregion

		#region Helpers
		/// <summary>
		/// Compiles a single XSL file to the _assemblyBuilder, but doesn't save it.
		/// </summary>
		private bool CompileInternal(string xsl, string className, ModuleBuilder builder)
		{
			// Args checking
			if (string.IsNullOrEmpty(xsl))
				throw new ArgumentNullException("No XSL content specified.");

			if (string.IsNullOrEmpty(className))
				throw new ArgumentNullException("No class name specified.");

			if (string.IsNullOrEmpty(Path))
				throw new InvalidOperationException("Path is null or empty.");

			if (builder == null)
			{
				// Default the assembly name to the filename
				if (string.IsNullOrEmpty(AssemblyName))
					AssemblyName = Filename;

				builder = this.CreateModuleBuilder(new AssemblyName(AssemblyName));
			}

			bool errors = false;
			Errors = new CompilerErrorCollection();

			TypeBuilder typeBuilder = builder.DefineType(className, TypeAttributes.BeforeFieldInit | TypeAttributes.Sealed | TypeAttributes.Abstract | TypeAttributes.Public);
			using (XmlReader xslReader = XmlReader.Create(new StringReader(xsl)))
			{
				Errors = XslCompiledTransform.CompileToType(xslReader, XsltSettings, XmlResolver, Debug, typeBuilder, GetFullPath(AssemblyName +".script.dll"));
			}

			foreach (CompilerError error in Errors)
			{
				errors |= !error.IsWarning;
			}

			// errors contains a C-like false for no errors, so reverse this as we're returning whether the operation succeeded.
			return !errors;
		}

		/// <summary>
		/// Creates an assembly builder.
		/// </summary>
		private ModuleBuilder CreateModuleBuilder(AssemblyName asmName)
		{
			_assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Save, Path);
			return _assemblyBuilder.DefineDynamicModule(Filename, Filename, EmitSymbols);
		}

		/// <summary>
		/// Adds a seperator to a filepath if needed.
		/// </summary>
		private string GetFullPath(string filename)
		{
			string seperator = "";
			if (!Path.EndsWith("/"))
					seperator = System.IO.Path.DirectorySeparatorChar.ToString();

			return string.Format("{0}{1}{2}", Path, seperator, filename);
		}
		#endregion
	}

	/// <summary>
	/// The exception that is thrown when an error occurs during XSL compilation.
	/// </summary>
	public class XslCompilerException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="XslCompilerException">XslCompilerException</see> class,
		/// with the provided error message.
		/// </summary>
		public XslCompilerException(string message) : base(message) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="XslCompilerException">XslCompilerException</see> class,
		/// with the provided error message and exception.
		/// </summary>
		public XslCompilerException(string message, Exception innerException) : base(message, innerException) { }
	}
}