using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DNIC.Erechtheion.Models;
using DNIC.Erechtheion.Services;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Core.Configuration;
using System.IdentityModel.Tokens.Jwt;
using DNIC.Erechtheion.EntityFrameworkCore;

namespace DNIC.Erechtheion
{
	public class Startup
	{
		public IErechtheionConfiguration Configuration { get; }
		public IHostingEnvironment Environment { get; }

		public Startup(IHostingEnvironment env)
		{
			Environment = env;

			var configurationFile = env.IsDevelopment() ? $"appsettings.{env.EnvironmentName}.json" : $"appsettings.json";
			IConfigurationBuilder builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile(configurationFile, optional: true, reloadOnChange: true)
				.AddEnvironmentVariables();
			Configuration = new ErechtheionConfiguration(builder.Build());
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddEntityFrameworkSqlServer()
			 .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.ConnectionString, b => b.UseRowNumberForPaging()));

			//services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

			// Add application services.
			services.AddTransient<IEmailSender, EmailSender>();

			services.AddMvc();

			services.AddResponseCompression();
			services.AddMvc();

			// 重新注册
			services.AddSingleton(Configuration.Configuration);
			// 注册系统配置
			services.AddSingleton(Configuration);

			DependencyInjectionConfig.Inject(services);

			services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

			// 如果没有配置全局登录系统, 则使用默认注册和登录
			if (!string.IsNullOrWhiteSpace(Configuration.AccountCenter))
			{
				JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

				services.AddAuthentication(options =>
				{
					options.DefaultScheme = "Cookies";
					options.DefaultChallengeScheme = "oidc";
				})
					.AddCookie("Cookies")
					.AddOpenIdConnect("oidc", options =>
					{
						options.SignInScheme = "Cookies";

						options.Authority = "http://localhost:5000";
						options.RequireHttpsMetadata = false;

						options.ClientId = "mvc";
						options.ClientSecret = "secret";
						options.ResponseType = "code id_token";

						options.SaveTokens = true;
						options.GetClaimsFromUserInfoEndpoint = true;

						options.Scope.Add("api1");
						options.Scope.Add("offline_access");
					});
			}
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
