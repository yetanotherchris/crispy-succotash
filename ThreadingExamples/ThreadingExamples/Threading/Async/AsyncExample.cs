using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

// For AsyncResult
using System.Runtime.Remoting.Messaging;

namespace MasterConsoleApp
{
	// http://stackoverflow.com/questions/1784928/c-four-patterns-in-asynchronous-execution

	// 4 types of delegate async calls:
	// http://msdn.microsoft.com/en-us/library/2e08f6yc.aspx
	//
	// Not to be confused with Control.BeginInvoke
	//
	// - Fire and forget
	// - I will call you
	// - You call me
	// - Polling 
	// - Fire and forget, with a callback method
	public class AsyncExample
	{
		public void FireAndForget()
		{
			// The delegate to invoke
			Action<string> doWork = DoWork;

			// 'Fire and forget' is the name parameter
			// The method is executed on a ThreadPool thread when the asynchronous call completes. 
			IAsyncResult result = doWork.BeginInvoke("Fire and forget", null, null);
			doWork.EndInvoke(result);
		}

		public void IWillCallYou()
		{
			// Same as FireAndForget
			Action<string> doWork = DoWork;
			IAsyncResult result = doWork.BeginInvoke("I will call you", null, null);

			// You "call the method" - wait 10 seconds for the method to finish.
			bool success = result.AsyncWaitHandle.WaitOne(10 * 1000);
			if (success)
				Console.WriteLine("DoWork completed sucessfully");
			else
				Console.WriteLine("DoWork timed out after 10 seconds");

			// If we call EndInvoke here, it will block until DoWork is completed. According to the documentation,
			// you *must* call EndInvoke(). See http://stackoverflow.com/questions/532722/is-endinvoke-optional-sort-of-optional-or-definitely-not-optional/532732#532732
			// and http://stackoverflow.com/questions/1274276/must-every-begininvoke-be-followed-by-an-endinvoke
			//doWork.EndInvoke(result);
			//Console.WriteLine("Doney");

			// [MSDN]
			// The wait handle is not closed automatically when you call EndInvoke. If you release all references to 
			// the wait handle, system resources are freed when garbage collection reclaims the wait handle. To 
			// free the system resources as soon as you are finished using the wait handle, dispose of it by 
			// calling the WaitHandle.Close method. Garbage collection works more efficiently when disposable objects are explicitly disposed.
			result.AsyncWaitHandle.Close();
		}

		public void Callback()
		{
			// The delegate to invoke
			Action<string> doWork = DoWork;

			// The method to call when complete
			AsyncCallback callback = Complete;

			// The parameter to send to the delegate
			string state = "state";

			// 'Fire and forget' is the name parameter
			// state is usable by callback method (Complete)
			// The method is executed on a ThreadPool thread when the asynchronous call completes. 
			IAsyncResult result = doWork.BeginInvoke("Fire and forget", callback, state);
			doWork.EndInvoke(result);
		}

		private void DoWork(string name)
		{
			Console.WriteLine("DoWork called. name: {0}, thread id {1}", name, Thread.CurrentThread.ManagedThreadId);
		}

		private void Complete(IAsyncResult result)
		{
			Console.WriteLine("Complete called. Thread id {0}", Thread.CurrentThread.ManagedThreadId);

			// This contains the 'state' string passed in
			string state = (string)result.AsyncState;
			Console.WriteLine("State: {0}", state);

			// EndInvoke needs the original delegate, which is done via Remoting with an AsyncResult.
			// EndInvoke is part of the contract, and should be called.
			AsyncResult asyncResult = (AsyncResult)result;
			((Action<string>)asyncResult.AsyncDelegate).EndInvoke(result);
		}
	}
}
