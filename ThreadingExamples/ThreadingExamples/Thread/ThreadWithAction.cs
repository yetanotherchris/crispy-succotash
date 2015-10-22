using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingExamples
{
	public class ThreadWithAction
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="doneAction">The delegate to call once the worker has finished.
		/// This won't be on the UI thread, and will require an Invoke.</param>
		public void Run(Action doneAction)
		{
			var worker = new ActionThreadWorker();
			Thread thread = new Thread(worker.Run);
			thread.Name = "Action thread";
			thread.Start(doneAction);
		}
	}

	public class ActionThreadWorker
	{
		public void Run(object state)
		{
			Action action = (Action)state;
			// Do a task

			action.Invoke();
		}
	}
}
