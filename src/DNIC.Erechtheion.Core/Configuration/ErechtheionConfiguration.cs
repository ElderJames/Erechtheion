using Microsoft.Extensions.Configuration;
using System;

namespace DNIC.Erechtheion.Core.Configuration
{
	public class ErechtheionConfiguration : IErechtheionConfiguration
	{
		public IConfiguration Configuration { get; }

		public ErechtheionConfiguration(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public string AccountCenter
		{
			get
			{
				var accountCenterStr = Configuration.GetSection(ErechtheionConsts.Erechtheion).GetValue<string>(ErechtheionConsts.AccountCenter);
				if (string.IsNullOrWhiteSpace(accountCenterStr))
				{
					return null;
				}
				else
				{
					if (Uri.TryCreate(accountCenterStr, UriKind.RelativeOrAbsolute, out _))
					{
						return accountCenterStr;
					}
					else
					{
						throw new ErechtheionException("Illegal value for AccountCenter.");
					}
				}
			}
		}

		public string ConnectionString => Configuration.GetConnectionString("DefaultConnection");
	}
}
