using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MasterConsoleApp
{
	public class CatchThreadException
	{
		public void Run()
		{
			try
			{
				Thread thread1 = new Thread(ThreadEntry1);
				thread1.Start();
			}
			catch (ThreadInterruptedException)
			{
				Console.WriteLine("Thread1 broke");
			}
		}

		private void ThreadEntry1()
		{
			throw new NotImplementedException("Oops");
		}
	}
}
