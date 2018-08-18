using System;
using System.Runtime.Serialization;

namespace ProgramacionOrientadaObjetosII
{
	[Serializable]
	internal class formatexception : Exception
	{
		public formatexception()
		{
		}

		public formatexception(string message) : base(message)
		{
		}

		public formatexception(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected formatexception(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}