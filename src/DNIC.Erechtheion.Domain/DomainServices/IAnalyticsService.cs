using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNIC.Erechtheion.Domain.DomainServices
{
	public interface IAnalyticsService
	{
		Task IncreaseAsync(string key);
		Task DecreaseAsync(string key);
		Task<int> GetByKeyAsync(string key);
		Task<IEnumerable<Analytics>> GetByKeysAsync(IEnumerable<string> keys);
	}

	public class AnalyticsService : IAnalyticsService
	{
		private readonly IAnalyticsReository analyticsReository;

		public AnalyticsService(IAnalyticsReository analyticsReository)
		{
			this.analyticsReository = analyticsReository;
		}

		public async Task DecreaseAsync(string key)
		{
			await analyticsReository.DecreaseAsync(key);
		}

		public async Task<int> GetByKeyAsync(string key)
		{
			return await analyticsReository.GetByKeyAsync(key);
		}

		public async Task<IEnumerable<Analytics>> GetByKeysAsync(IEnumerable<string> keys)
		{
			return await analyticsReository.GetByKeysAsync(keys);
		}

		public async Task IncreaseAsync(string key)
		{
			await analyticsReository.IncreaseAsync(key);
		}
	}
}
