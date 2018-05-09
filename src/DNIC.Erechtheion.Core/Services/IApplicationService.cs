using DNIC.Erechtheion.Core.Dependency;

namespace DNIC.Erechtheion.Core.Services
{
	/// <summary>
	/// This interface must be implemented by all application services to identify them by convention.
	/// </summary>
	public interface IApplicationService : ITransientDependency
	{

	}
}
