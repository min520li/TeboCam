// Motion Detector
//
// Copyright © Andrew Kirillov, 2005
// andrew.kirillov@gmail.com
//
namespace VideoSource
{
	using System;
	using System.Drawing;
	using System.IO;
	using System.Threading;
	using System.Net;

	/// <summary>
	/// JPEGSource - JPEG downloader
	/// </summary>
	public class JPEGStream : IVideoSource
	{
		private string	source;
		private string	login = null;
		private string	password = null;
		private object	userData = null;
		private int		framesReceived;
		private int		bytesReceived;
		private bool	useSeparateConnectionGroup = false;
		private bool	preventCaching = false;
		private int		frameInterval = 0;		// frame interval in miliseconds

		private const int	bufSize = 512 * 1024;	// buffer size
		private const int	readSize = 1024;		// portion size to read

		private Thread	thread = null;
		private ManualResetEvent stopEvent = null;

		// new frame event
		public event CameraEventHandler NewFrame;

		// SeparateConnectioGroup property
		// indicates to open WebRequest in separate connection group
		public bool	SeparateConnectionGroup
		{
			get { return useSeparateConnectionGroup; }
			set { useSeparateConnectionGroup = value; }
		}
		// PreventCaching property
		// If the property is set to true, we are trying to prevent caching
		// appneding fake parameter to URL. It's needed is client is behind
		// proxy server.
		public bool	PreventCaching
		{
			get { return preventCaching; }
			set { preventCaching = value; }
		}
		// FrameInterval property - interval between frames
		// If the property is set 100, than the source will produce 10 frames
		// per second if it possible
		public int FrameInterval
		{
			get { return frameInterval; }
			set { frameInterval = value; }
		}
		// VideoSource property
		public virtual string VideoSource
		{
			get { return source; }
			set { source = value; }
		}
		// Login property
		public string Login
		{
			get { return login; }
			set { login = value; }
		}
		// Password property
		public string Password
		{
			get { return password; }
			set { password = value; }
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
			get
			{
				int bytes = bytesReceived;
				bytesReceived = 0;
				return bytes;
			}
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
		public JPEGStream()
		{
		}

		// Start work
		public void Start()
		{
			if (thread == null)
			{
				framesReceived = 0;
				bytesReceived = 0;

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
			byte[]			buffer = new byte[bufSize];	// buffer to read stream
			HttpWebRequest	req = null;
			WebResponse		resp = null;
			Stream			stream = null;
			Random			rnd = new Random((int) DateTime.Now.Ticks);
			DateTime		start;
			TimeSpan		span;

			while (true)
			{
				int	read, total = 0;

				try
				{
					start = DateTime.Now;

					// create request
					if (!preventCaching)
					{
						req = (HttpWebRequest) WebRequest.Create(source);
					}
					else
					{
						req = (HttpWebRequest) WebRequest.Create(source + ((source.IndexOf('?') == -1) ? '?' : '&') + "fake=" + rnd.Next().ToString());
					}
					// set login and password
					if ((login != null) && (password != null) && (login != ""))
						req.Credentials = new NetworkCredential(login, password);
					// set connection group name
					if (useSeparateConnectionGroup)
						req.ConnectionGroupName = GetHashCode().ToString();
					// get response
					resp = req.GetResponse();

					// get response stream
					stream = resp.GetResponseStream();

					// loop
					while (!stopEvent.WaitOne(0, true))
					{
						// check total read
						if (total > bufSize - readSize)
						{
							System.Diagnostics.Debug.WriteLine("flushing");
							total = 0;
						}

						// read next portion from stream
						if ((read = stream.Read(buffer, total, readSize)) == 0)
							break;

						total += read;

						// increment received bytes counter
						bytesReceived += read;
					}

					if (!stopEvent.WaitOne(0, true))
					{
						// increment frames counter
						framesReceived++;

						// image at stop
						if (NewFrame != null)
						{
							Bitmap	bmp = (Bitmap) Bitmap.FromStream(new MemoryStream(buffer, 0, total));
							// notify client
							NewFrame(this, new CameraEventArgs(bmp));
							// release the image
							bmp.Dispose();
							bmp = null;
						}
					}

					// wait for a while ?
					if (frameInterval > 0)
					{
						// times span
						span = DateTime.Now.Subtract(start);
						// miliseconds to sleep
						int msec = frameInterval - (int) span.TotalMilliseconds;

						while ((msec > 0) && (stopEvent.WaitOne(0, true) == false))
						{
							// sleeping ...
							Thread.Sleep((msec < 100) ? msec : 100);
							msec -= 100;
						}
					}
				}
				catch (WebException ex)
				{
					System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
					// wait for a while before the next try
					Thread.Sleep(250);
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine("=============: " + ex.Message);
				}
				finally
				{
					// abort request
					if (req != null)
					{
						req.Abort();
						req = null;
					}
					// close response stream
					if (stream != null)
					{
						stream.Close();
						stream = null;
					}
					// close response
					if (resp != null)
					{
						resp.Close();
						resp = null;
					}
				}

				// need to stop ?
				if (stopEvent.WaitOne(0, true))
					break;
			}
		}
	}
}
