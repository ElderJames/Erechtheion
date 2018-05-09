using DNIC.Erechtheion.Core.Domain.Repositories;
using DNIC.Erechtheion.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNIC.Erechtheion.Domain.Repositories
{
	public interface IAnalyticsReository : IRepository
	{
		Task IncreaseAsync(string key);
		Task DecreaseAsync(string key);
		Task<int> GetByKeyAsync(string key);
		Task<IEnumerable<Analytics>> GetByKeysAsync(IEnumerable<string> keys);
	}
}
