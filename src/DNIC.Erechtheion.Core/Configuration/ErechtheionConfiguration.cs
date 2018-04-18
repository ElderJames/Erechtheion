using DNIC.Erechtheion.Core.CustomExceptions;
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

		public string ConnectionString => Configuration.GetConnectionString("DefaultConnection");

		#region AccountCenter

		public AuthenticationMode AuthenticationMode => Configuration.GetSection(ErechtheionConsts.Erechtheion).GetValue<AuthenticationMode>(ErechtheionConsts.AuthenticationMode);

		public string Authority
		{
			get
			{
				var accountCenterStr = Configuration.GetSection(ErechtheionConsts.Authentication).GetValue<string>(ErechtheionConsts.Authority);
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

		public string DefaultScheme => Configuration.GetSection(ErechtheionConsts.Authentication).GetValue<string>(ErechtheionConsts.DefaultScheme);

		public string ApiName => Configuration.GetSection(ErechtheionConsts.Authentication).GetValue<string>(ErechtheionConsts.ApiName);

		public bool RequireHttpsMetadata => Configuration.GetSection(ErechtheionConsts.Authentication).GetValue<bool>(ErechtheionConsts.RequireHttpsMetadata);

		#endregion
	}
}

