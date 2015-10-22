using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingExamples
{
	public class WaitAllExample 
	{
		private const int _maxThreads = 25;

		public void Run()
		{
			ManualResetEvent[] manualEvents = new ManualResetEvent[_maxThreads];

			for (int i = 0; i < _maxThreads; i++)
			{
				using (ManualResetEvent manualResetEvent = new ManualResetEvent(false))
				{
					ThreadPool.QueueUserWorkItem(new WaitCallback(ManualWaitHandleThread), new FileState("filename", manualResetEvent));
					manualEvents[i] = manualResetEvent;
				}
			}

			WaitHandle.WaitAll(manualEvents);
		}

		public void ManualWaitHandleThread(object state)
		{
			FileState filestate = (FileState) state; 
			Thread.Sleep(100);
			filestate.ManualEvent.Set();
		}

		/// <summary>
		/// An imaginary class for holding some kind of state.
		/// </summary>
		private class FileState
		{
			public string Filename { get;set; }
			public ManualResetEvent ManualEvent { get; set; }

			public FileState(string fileName, ManualResetEvent manualEvent)
			{
				Filename = fileName;
				ManualEvent = manualEvent;
			}
		}
	}
}
