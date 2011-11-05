// Motion Detector
//
// Copyright © Andrew Kirillov, 2005
// andrew.kirillov@gmail.com
//
namespace VideoSource
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using System.IO;
	using System.Threading;

	using Tiger.Video.VFW;

	/// <summary>
	/// VideoFileSource
	/// </summary>
	public class VideoFileSource : IVideoSource
	{
		private string	source;
		private object	userData = null;
		private int		framesReceived;

		private Thread	thread = null;
		private ManualResetEvent stopEvent = null;

		// new frame event
		public event CameraEventHandler NewFrame;

		// VideoSource property
		public virtual string VideoSource
		{
			get { return source; }
			set { source = value; }
		}
		// Login property
		public string Login
		{
			get { return null; }
			set { }
		}
		// Password property
		public string Password
		{
			get { return null; }
			set { }
		}
		// FramesReceived property
		public int FramesReceived
		{
			get
			{
				int frames = framesReceived;
				framesReceived = 0;
				return frames;
			}
		}
		// BytesReceived property
		public int BytesReceived
		{
			get { return 0; }
		}
		// UserData property
		public object UserData
		{
			get { return userData; }
			set { userData = value; }
		}
		// Get state of the video source thread
		public bool Running
		{
			get
			{
				if (thread != null)
				{
					if (thread.Join(0) == false)
						return true;

					// the thread is not running, so free resources
					Free();
				}
				return false;
			}
		}


		// Constructor
		public VideoFileSource()
		{
		}

		// Start work
		public void Start()
		{
			if (thread == null)
			{
				framesReceived = 0;

				// create events
				stopEvent	= new ManualResetEvent(false);
				
				// create and start new thread
				thread = new Thread(new ThreadStart(WorkerThread));
				thread.Name = source;
				thread.Start();
			}
		}

		// Signal thread to stop work
		public void SignalToStop()
		{
			// stop thread
			if (thread != null)
			{
				// signal to stop
				stopEvent.Set();
			}
		}

		// Wait for thread stop
		public void WaitForStop()
		{
			if (thread != null)
			{
				// wait for thread stop
				thread.Join();

				Free();
			}
		}

		// Abort thread
		public void Stop()
		{
			if (this.Running)
			{
				thread.Abort();
				WaitForStop();
			}
		}

		// Free resources
		private void Free()
		{
			thread = null;

			// release events
			stopEvent.Close();
			stopEvent = null;
		}

		// Thread entry point
		public void WorkerThread()
		{
			AVIReader	aviReader = new AVIReader();

			try
			{
				// open file
				aviReader.Open(source);

				while (true)
				{
					// start time
					DateTime	start = DateTime.Now;

					// get next frame
					Bitmap	bmp = aviReader.GetNextFrame();

					framesReceived++;

					// need to stop ?
					if (stopEvent.WaitOne(0, false))
						break;

					if (NewFrame != null)
						NewFrame(this, new CameraEventArgs(bmp));

					// free image
					bmp.Dispose();

					// end time
					TimeSpan	span = DateTime.Now.Subtract(start);

					// sleep for a while
/*					int			m = (int) span.TotalMilliseconds;

					if (m < 100)
						Thread.Sleep(100 - m);*/
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("exception : " + ex.Message);
			}

			aviReader.Dispose();
			aviReader = null;
		}
	}
}
