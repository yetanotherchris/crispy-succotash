using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingExamples
{
	public class ThreadWithEvent
	{
		public void Run()
		{
			var worker = new EventThreadWorker();
			worker.ThreadDone += HandleWithEvent;
			Thread thread = new Thread(worker.Run);
			thread.Name = "Event thread";
			thread.Start();
		}

		private void HandleWithEvent(object sender, EventArgs e)
		{
			Console.WriteLine("Event: I'm on {0}", Thread.CurrentThread.Name);
		}
	}

	public class EventThreadWorker
	{
		public event EventHandler ThreadDone;

		public void Run()
		{
			// Do a task

			if (ThreadDone != null)
				ThreadDone(this, EventArgs.Empty);
		}
	}
}
