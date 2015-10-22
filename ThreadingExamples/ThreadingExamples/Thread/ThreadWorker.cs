using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingExamples
{
	public class ThreadWorker
	{
		public void Run()
		{
			try
			{

				

				Console.WriteLine("Run called for {0}", Thread.CurrentThread.Name);
				LongTask();
			}
			catch (ThreadAbortException)
			{

			}
			catch (ThreadInterruptedException)
			{
				Console.WriteLine("ThreadInterruptedException thrown");
			}
		}

		public void LongTask()
		{
			Thread.Sleep(5000); Console.WriteLine("5 seconds");
			Thread.Sleep(10000); Console.WriteLine("10 seconds");
			Thread.Sleep(20000); Console.WriteLine("20 seconds");
		}
	}
}
