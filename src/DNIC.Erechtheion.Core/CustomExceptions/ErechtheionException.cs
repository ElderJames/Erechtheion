using System;
using System.Runtime.Serialization;

namespace DNIC.Erechtheion.Core.CustomExceptions
{
	public class ErechtheionException : Exception
	{
		/// <summary>
		/// Creates a new <see /> object.
		/// </summary>
		public ErechtheionException()
		{

		}

		/// <summary>
		/// Creates a new <see /> object.
		/// </summary>
		public ErechtheionException(SerializationInfo serializationInfo, StreamingContext context)
			: base(serializationInfo, context)
		{

		}

		/// <summary>
		/// Creates a new <see /> object.
		/// </summary>
		/// <param name="message">Exception message</param>
		public ErechtheionException(string message)
			: base(message)
		{

		}

		/// <summary>
		/// Creates a new <see /> object.
		/// </summary>
		/// <param name="message">Exception message</param>
		/// <param name="innerException">Inner exception</param>
		public ErechtheionException(string message, Exception innerException)
			: base(message, innerException)
		{

		}
	}
}
