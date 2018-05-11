using System.Data.SqlClient;
using DNIC.Erechtheion.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DNIC.Erechtheion.Services;
using DNIC.Erechtheion.Core.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using DNIC.Erechtheion.Domain.Entities;
using AspNetCore.Identity.Dapper;
using DNIC.Erechtheion.Core;
using System.Data.Common;
using DNIC.Erechtheion.Repositories.Dapper;
using DNIC.Erechtheion.Queries.Dapper;

namespace DNIC.Erechtheion
{
	public class Startup
	{
		public IConfigurationRoot Configuration { get; }
		public IHostingEnvironment Environment { get; }

		public Startup(IHostingEnvironment env)
		{
			Environment = env;

			var configurationFile = env.IsDevelopment() ? $"appsettings.{env.EnvironmentName}.json" : $"appsettings.json";
			IConfigurationBuilder builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile(configurationFile, optional: true, reloadOnChange: true)
				.AddEnvironmentVariables();

			Configuration = builder.Build();

			// 配置 Serilog
			Log.Logger = new LoggerConfiguration()
				.Enrich.FromLogContext()
				.ReadFrom.Configuration(Configuration)
				.WriteTo.Console().WriteTo.File("DNIC.Erechtheion.log")
				.CreateLogger();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add application services.
			services.AddTransient<IEmailSender, EmailSender>();

			services.AddResponseCompression();
			services.AddResponseCaching();
			services.AddMvc();
			services.AddAuthorization();

			//注册web所需
			var erechtheionBuilder = services.AddErechtheion(config =>
			{
				config.UseConfiguration(Configuration);
				config.UseDbProviderFactory(SqlClientFactory.Instance);
				config.UseDapperRepositories();
				config.UseDapperQueries();
			});

			if ((erechtheionBuilder.Configuratoin.AuthenticationMode & AuthenticationMode.Self) == AuthenticationMode.Self)
			{
				services.AddIdentity<ErechtheionUser, IdentityRole>(config =>
				{
					config.User.RequireUniqueEmail = true;
					config.Password = new PasswordOptions
					{
						RequireDigit = true,
						RequireUppercase = false,
						RequireLowercase = true,
						RequiredLength = 6
					};
					config.SignIn.RequireConfirmedEmail = false;
					config.SignIn.RequireConfirmedPhoneNumber = false;
				}).AddDapperStores(new SqlServerProvider(erechtheionBuilder.Configuratoin.ConnectionString)).AddDefaultTokenProviders();
			}

			// 如果没有配置全局登录系统, 则使用默认注册和登录
			if ((erechtheionBuilder.Configuratoin.AuthenticationMode & AuthenticationMode.External) == AuthenticationMode.External)
			{
				services.AddAuthentication("Cookies")
				.AddCookie("Cookies")
				.AddOpenIdConnect("oidc", options =>
				{
					options.SignInScheme = IdentityConstants.ExternalScheme;

					options.Authority = erechtheionBuilder.Configuratoin.Authority;
					options.RequireHttpsMetadata = erechtheionBuilder.Configuratoin.RequireHttpsMetadata;

					options.ClientId = "DNIC.Erechtheion";
					options.ClientSecret = "secret";
					options.ResponseType = "code id_token";

					options.SaveTokens = true;
					options.GetClaimsFromUserInfoEndpoint = true;
				});
			}
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();
			loggerFactory.AddSerilog();

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