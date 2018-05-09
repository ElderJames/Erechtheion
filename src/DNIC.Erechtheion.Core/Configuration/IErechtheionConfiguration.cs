using Microsoft.Extensions.Configuration;

namespace DNIC.Erechtheion.Core.Configuration
{
	public interface IErechtheionConfiguration
	{
		#region Authentication

		AuthenticationMode AuthenticationMode { get; }
		string Authority { get; }
		string DefaultScheme { get; }
		bool RequireHttpsMetadata { get; }
		string ApiName { get; }

		#endregion

		string ConnectionString { get; }
		IConfiguration Configuration { get; }
	}
}
