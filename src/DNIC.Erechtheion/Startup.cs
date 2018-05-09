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
using DNIC.Erechtheion.QuerySerivces.SmartSql;
using DNIC.Erechtheion.Repositories.SmartSql;
using DNIC.Erechtheion.Domain.Entities;
using AspNetCore.Identity.Dapper;

namespace DNIC.Erechtheion
{
	public class Startup
	{
		public IErechtheionConfiguration ErechtheionConfiguration { get; }
		public IHostingEnvironment Environment { get; }

		public Startup(IHostingEnvironment env)
		{
			Environment = env;

			var configurationFile = env.IsDevelopment() ? $"appsettings.{env.EnvironmentName}.json" : $"appsettings.json";
			IConfigurationBuilder builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile(configurationFile, optional: true, reloadOnChange: true)
				.AddEnvironmentVariables();
			ErechtheionConfiguration = new ErechtheionConfiguration(builder.Build());

			// 配置 Serilog
			Log.Logger = new LoggerConfiguration()
				.Enrich.FromLogContext()
				.ReadFrom.Configuration(ErechtheionConfiguration.Configuration)
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

			// 重新注册
			services.AddSingleton(ErechtheionConfiguration.Configuration);

			services.AddSingleton(ErechtheionConfiguration);

			//注册web所需
			services.AddErechtheion();

			//注册应用服务里的服务，分离后在服务端注册，AddErechtheion里注册客户端
			services.AddErechtheionServices(config =>
			{
				//config.UseEntityFrameworkCore(options => options.UseSqlServer(ErechtheionConfiguration.ConnectionString, b => b.UseRowNumberForPaging()));
				config.UseSmartSqlRepositories(options =>
				{
					options.ConnectionString = ErechtheionConfiguration.ConnectionString;
					options.SqlMapperPath = "SqlMaps";
					options.DbProviderFactory = SqlClientFactory.Instance;
					options.LoggingName = ErechtheionConfiguration.ApiName;
					options.UseManifestResource = true;
				});

				config.UseSmartSqlQueryServices(options =>
				{
					options.ConnectionString = ErechtheionConfiguration.ConnectionString;
					options.SqlMapperPath = "SqlMaps";
					options.DbProviderFactory = SqlClientFactory.Instance;
					options.LoggingName = ErechtheionConfiguration.ApiName;
					options.UseManifestResource = true;
				});
			});

			if ((ErechtheionConfiguration.AuthenticationMode & AuthenticationMode.Self) == AuthenticationMode.Self)
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
				}).AddDapperStores(new SqlServerProvider(ErechtheionConfiguration.ConnectionString)).AddDefaultTokenProviders();
			}

			// 如果没有配置全局登录系统, 则使用默认注册和登录
			if ((ErechtheionConfiguration.AuthenticationMode & AuthenticationMode.External) == AuthenticationMode.External)
			{
				services.AddAuthentication("Cookies")
				.AddCookie("Cookies")
				.AddOpenIdConnect("oidc", options =>
				{
					options.SignInScheme = IdentityConstants.ExternalScheme;

					options.Authority = ErechtheionConfiguration.Authority;
					options.RequireHttpsMetadata = ErechtheionConfiguration.RequireHttpsMetadata;

					options.ClientId = "DNIC.Erechtheion";
					options.ClientSecret = "secret";
					options.ResponseType = "code id_token";

					options.SaveTokens = true;
					options.GetClaimsFromUserInfoEndpoint = true;
				})
				;
			}
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(ErechtheionConfiguration.Configuration.GetSection("Logging"));
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