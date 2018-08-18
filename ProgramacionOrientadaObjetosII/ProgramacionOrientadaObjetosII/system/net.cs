using System;
using System.Runtime.Serialization;

namespace system
{
	internal class net
	{
		internal class mail
		{
			[Serializable]
			internal class smtpexception : Exception
			{
				public smtpexception()
				{
				}

				public smtpexception(string message) : base(message)
				{
				}

				public smtpexception(string message, Exception innerException) : base(message, innerException)
				{
				}

				protected smtpexception(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}

			internal class mailmessage
			{
				internal object to;
			}
		}
	}
}