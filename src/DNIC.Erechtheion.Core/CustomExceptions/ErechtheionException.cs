using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DNIC.Erechtheion.Core.CustomExceptions
{
	public class ErechtheionException : Exception
	{
		/// <summary>
		/// Creates a new <see cref="AbpException"/> object.
		/// </summary>
		public ErechtheionException()
		{

		}

		/// <summary>
		/// Creates a new <see cref="AbpException"/> object.
		/// </summary>
		public ErechtheionException(SerializationInfo serializationInfo, StreamingContext context)
			: base(serializationInfo, context)
		{

		}

		/// <summary>
		/// Creates a new <see cref="AbpException"/> object.
		/// </summary>
		/// <param name="message">Exception message</param>
		public ErechtheionException(string message)
			: base(message)
		{

		}

		/// <summary>
		/// Creates a new <see cref="AbpException"/> object.
		/// </summary>
		/// <param name="message">Exception message</param>
		/// <param name="innerException">Inner exception</param>
		public ErechtheionException(string message, Exception innerException)
			: base(message, innerException)
		{

		}
	}
}
