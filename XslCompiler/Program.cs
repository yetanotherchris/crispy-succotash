using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Xsl;
using System.Xml;
using System.Reflection;

namespace XslTools
{
	class Program
	{
		static void Main(string[] args)
		{
			Tester tester = new Tester();
			tester.CompileTestSingle();
			//tester.CompileTestSingleFile();
			//tester.CompileTestMultiple();
			//tester.CompileTestMultipleFiles();
		}
	}

	public class Tester
	{
		private string _path = AppDomain.CurrentDomain.BaseDirectory;

		public void CompileTestSingle()
		{
			string path = _path;
			string assemblyName = "MyNameSpace";
			string dllFile = string.Format("{0}.dll", assemblyName);
			string fullPath = string.Format("{0}/{1}", path, dllFile);
			string classname = "MyNameSpace.Class";

			// This would usually come from the database
			string xsl = File.ReadAllText(MapPath("/example.xslt"));

			XslCompiler compiler = new XslCompiler(path, dllFile);
			compiler.Compile(xsl, classname);

			string xml = File.ReadAllText(MapPath("/example.xml"));
			string result = TransformWithAssembly(fullPath, classname, xml);
		}

		public void CompileTestMultiple()
		{
			string path = _path;
			string assemblyName = "MyNameSpace";
			string dllFile = string.Format("{0}.dll", assemblyName);
			string fullPath = string.Format("{0}/{1}", path, dllFile);
			string classname = "MyNameSpace.Class";
			string classname2 = "MyNameSpace.Class2";

			// This would usually come from the database
			string xsl1 = File.ReadAllText(MapPath("/example.xslt"));
			string xsl2 = File.ReadAllText(MapPath("/example2.xslt"));

			Dictionary<string, string> classList = new Dictionary<string, string>();
			classList.Add(classname, xsl1);
			classList.Add(classname2, xsl2);

			XslCompiler compiler = new XslCompiler(path, dllFile);
			compiler.CompileMultiple(classList);

			string xml = File.ReadAllText(MapPath("/example.xml"));
			string result = TransformWithAssembly(fullPath, classname2, xml);
		}

		public void CompileTestSingleFile()
		{
			//
			// Two XSLs in one file
			//

			string path = _path;
			string assemblyName = "MyNameSpace";
			string dllFile = string.Format("{0}.dll", assemblyName);
			string fullPath = string.Format("{0}/{1}", path, dllFile);
			string classname = "MyNameSpace.Class";
			string classname2 = "MyNameSpace.Class2";

			XslCompiler compiler = new XslCompiler(path, dllFile);
			compiler.CompileFromFile(MapPath("/example.xslt"), classname);
			compiler.CompileFromFile(MapPath("/example2.xslt"), classname2);

			string xml = File.ReadAllText(MapPath("/example.xml"));
			string result = TransformWithAssembly(fullPath, classname2, xml);
		}

		public void CompileTestMultipleFiles()
		{
			//
			// Two XSLs in one file, using a list to add them
			//

			string path = _path;
			string assemblyName = "MyNameSpace";
			string dllFile = string.Format("{0}.dll", assemblyName);
			string fullPath = string.Format("{0}/{1}", path, dllFile);
			string classname = "MyNameSpace.Class";
			string classname2 = "MyNameSpace.Class2";

			Dictionary<string, string> filelist = new Dictionary<string, string>();
			filelist.Add(classname, path + "example.xslt");
			filelist.Add(classname2, path + "example2.xslt");

			XslCompiler compiler = new XslCompiler(path, dllFile);
			compiler.CompileFromFiles(filelist);

			string xml = File.ReadAllText(MapPath("/example.xml"));
			string result = TransformWithAssembly(fullPath, classname2, xml);
		}

		private string MapPath(string file)
		{
			return string.Format("{0}{1}",_path,file);
		}

		public string TransformWithAssembly(string assemblyPath, string classname, string xml)
		{
			StringBuilder output = new StringBuilder();
			XslCompiledTransform transform = new XslCompiledTransform(false);

			XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
			Assembly asm = Assembly.LoadFile(assemblyPath);
			transform.Load(asm.GetType(classname));

			XmlWriter writer = XmlWriter.Create(output, transform.OutputSettings);
			transform.Transform(xmlReader, writer);

			return output.ToString();
		}
	}
}
