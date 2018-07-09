using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace VSCodeDebug
{
	class LuaDebugSession : DebugSession
	{
		Socket socket;

		public LuaDebugSession()
		{
		}

		public override void Attach(Response response, dynamic arguments)
		{
			String address; int port;

			try
			{
				address = arguments.address;
				port = arguments.port;
			}catch(Exception e)
			{
				Program.Log("Problem with parsing adddr & port");
				return;
			}

			try
			{
				socket.Connect(address, port);
			}catch(Exception e)
			{
				Program.Log("Failed to connect to game at {0}:{1}.", address, port);
			}
			if(true || socket.Connected)
			{
				SendEvent(new InitializedEvent());
			}
			else
			{
				//error.
			}
		}

		public override void Continue(Response response, dynamic arguments)
		{
			
		}

		public override void Disconnect(Response response, dynamic arguments)
		{
			
		}

		public override void Evaluate(Response response, dynamic arguments)
		{
			
		}

		public override void Initialize(Response response, dynamic args)
		{
			
		}

		public override void Launch(Response response, dynamic arguments)
		{
			Program.Log("LAUNCH");
		}

		public override void Next(Response response, dynamic arguments)
		{
			
		}

		public override void Pause(Response response, dynamic arguments)
		{
			SendEvent(new StoppedEvent(1, "request"));
		}

		public override void Scopes(Response response, dynamic arguments)
		{
			
		}

		public override void SetBreakpoints(Response response, dynamic arguments)
		{
			
		}

		public override void Source(Response response, dynamic arguments)
		{
			
		}

		public override void StackTrace(Response response, dynamic arguments)
		{
			List<StackFrame> frames = new List<StackFrame>();
			
			response.SetBody(new StackTraceResponseBody(frames, frames.Count));
		}

		public override void StepIn(Response response, dynamic arguments)
		{
			
		}

		public override void StepOut(Response response, dynamic arguments)
		{
			
		}

		public override void Threads(Response response, dynamic arguments)
		{
			response.body = new ThreadsResponseBody(new List<Thread>() { new Thread(1, "Main thread") });
		}

		public override void Variables(Response response, dynamic arguments)
		{
			
		}
	}
}
