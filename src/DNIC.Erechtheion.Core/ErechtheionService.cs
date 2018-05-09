using Microsoft.Extensions.Logging;

namespace DNIC.Erechtheion.Core
{
	public abstract class ErechtheionService
	{
		/// <summary>
		/// Reference to the logger to write logs.
		/// </summary>
		public ILogger Logger { protected get; set; }
	}
}
