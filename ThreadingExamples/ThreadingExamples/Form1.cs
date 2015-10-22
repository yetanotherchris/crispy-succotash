using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;

namespace ThreadingExamples
{
	public partial class Form1 : Form
	{
		ThreadLauncher _launcher;

		public Form1()
		{
			Thread.CurrentThread.Name = "Main UI thread";
			Console.WriteLine("Main UI id: {0}",Thread.CurrentThread.ManagedThreadId);
			_launcher = new ThreadLauncher();
			InitializeComponent();
		}

		private void buttonLaunch_Click(object sender, EventArgs e)
		{
			_launcher.Launch();
		}

		private void buttonAbort_Click(object sender, EventArgs e)
		{
			_launcher.Abort();
		}

		private void buttonJoin_Click(object sender, EventArgs e)
		{
			_launcher.Join();
		}

		private void buttonInterrupt_Click(object sender, EventArgs e)
		{
			_launcher.Interrupt();
		}

		private void buttonEvent_Click(object sender, EventArgs e)
		{
		}

		private void buttonAction_Click(object sender, EventArgs e)
		{
			
		}

		

		// http://msdn.microsoft.com/en-us/library/2e08f6yc.aspx
		// Pass a delegate for a callback method to BeginInvoke. 
		// The method is executed on a ThreadPool thread when the asynchronous call completes. 
		// The callback method calls EndInvoke.
		private void buttonAsync_Click(object sender, EventArgs e)
		{
			AsyncCallback callback = AsyncComplete;
			Action<string> doWork = AsyncDoWork;
			string state = "state";
			doWork.BeginInvoke("bob",callback,state);
		}

		private void AsyncDoWork(string name)
		{
			Console.WriteLine("AsyncDoWork I'm on {0}", Thread.CurrentThread.Name);

			for (int i = 0; i < 50000; i++)
			{

			}
		}

		private void buttonWeb_Click(object sender, EventArgs e)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://onetwo");
			request.Method = "GET";
			request.ContentType = "text/html";
			request.BeginGetRequestStream(AsyncWebRequestComplete, request);
		}

		private void AsyncWebRequestComplete(IAsyncResult result)
		{
			HttpWebRequest request = (HttpWebRequest)result.AsyncState;

			request.EndGetRequestStream(result);
			request.BeginGetResponse(AsyncWebResponseComplete, request);
		}

		private void AsyncWebResponseComplete(IAsyncResult result)
		{
			HttpWebRequest request = (HttpWebRequest)result.AsyncState;
			WebResponse response = request.EndGetResponse(result);

			textBox1.Text = new StreamReader(response.GetResponseStream()).ReadToEnd();
		}

		private void AsyncComplete(IAsyncResult result)
		{
			System.Runtime.Remoting.Messaging.AsyncResult asyncResult = (System.Runtime.Remoting.Messaging.AsyncResult)result;
			((Action<string>)asyncResult.AsyncDelegate).EndInvoke(result);


			Console.WriteLine("AsyncComplete I'm on {0}", Thread.CurrentThread.ManagedThreadId);
			Console.WriteLine(result.AsyncState);
		}

		private void buttonAsync2_Click(object sender, EventArgs e)
		{
			AsyncCallback callback = AsyncComplete;
			Func<string,int> doWork = Async2DoWork;
			string state = "state";
			IAsyncResult result = doWork.BeginInvoke("bob",null, state); // null for no callback
			while (!result.IsCompleted)
			{
				
			}
			Console.WriteLine("Async finished with number: {0}",doWork.EndInvoke(result));
		}

		private int Async2DoWork(string name)
		{
			int result = 0;
			for (int i = 0; i < 500000; i++)
			{
				result = i;
			}

			return result;
		}

		private void buttonBeginInvoke_Click(object sender, EventArgs e)
		{
			//Thread thread = new Thread(TextBoxWorker);
			//thread.Start();
			TextBoxWorker();
		}

		void TextBoxWorker()
		{
			Action<int> action = new Action<int>(delegate(int i)
			{
				textBox1.AppendText(i + "\n");
			});

			for (int i = 0; i < 100000; i++)
			{
				var result = textBox1.BeginInvoke(action, i);
				textBox1.EndInvoke(result);
			}
		}

		private void buttonInvoke_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread(TextBoxInvokeEntry);
			thread.Start();
		}

		void TextBoxInvokeEntry()
		{
			for (int i = 0; i < 500000; i++)
			{
				TextBoxInvokeWorker(i);
			}
		}

		void TextBoxInvokeWorker(int i)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<int>(TextBoxInvokeWorker),i);
				return;
			}

			textBox1.AppendText(i + "\n");
		}

		private void buttonWaitHandle_Click(object sender, EventArgs e)
		{
			WaitAllExample waitall = new WaitAllExample();
			waitall.Run();
		}
	}

	public class ThreadLauncher
	{
		private int _maxThreads = 25;
		private List<Thread> _threads;

		public void Launch()
		{
			_threads = new List<Thread>();

			for (int i = 0; i < _maxThreads; i++)
			{
				ThreadWorker worker = new ThreadWorker();
				Thread thread = new Thread(worker.Run);
				thread.Name = string.Format("My Thread {0}", i);
				_threads.Add(thread);

				thread.Start();
			}
		}

		public void Abort()
		{
			Console.WriteLine("Abort started {0}", DateTime.Now.ToLongTimeString());

			for (int i = 0; i < _threads.Count; i++)
			{
				_threads[i].Abort();
			}

			Console.WriteLine("Abort finished {0}", DateTime.Now.ToLongTimeString());
		}

		public void Join()
		{
			Console.WriteLine("Join started {0}",DateTime.Now.ToLongTimeString());

			for (int i = 0; i < _threads.Count; i++)
			{
				_threads[i].Join();
			}

			Console.WriteLine("Join finished {0}", DateTime.Now.ToLongTimeString());
		}


		public void Interrupt()
		{
			Console.WriteLine("Interrupt started {0}", DateTime.Now.ToLongTimeString());

			for (int i = 0; i < _threads.Count; i++)
			{
				_threads[i].Interrupt();
			}

			Console.WriteLine("Interrupt finished {0}", DateTime.Now.ToLongTimeString());
		}
	}
}
