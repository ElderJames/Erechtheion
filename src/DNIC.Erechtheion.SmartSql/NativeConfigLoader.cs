using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using Serilog;
using SmartSql.Abstractions;
using SmartSql.Abstractions.Config;
using SmartSql.Common;
using SmartSql.SqlMap;

namespace DNIC.Erechtheion.SmartSql
{
	public class NativeConfigLoader : ConfigLoader
	{
		private const int DelayedLoadFile = 500;
		private readonly SmartSqlOptions _smartSqlOptions;
		private readonly List<(Assembly assembly, string[] names)> _assemblies;

		public void SetAssemblyOf(Assembly assembly)
		{
			_assemblies.Add((assembly, assembly.GetManifestResourceNames()));
		}

		public NativeConfigLoader(SmartSqlOptions options)
		{
			_smartSqlOptions = options;
			_assemblies = new List<(Assembly assembly, string[] names)>();
		}

		public override void Dispose()
		{
			FileWatcherLoader.Instance.Clear();
		}

		public override SmartSqlMapConfig Load(string path, ISmartSqlMapper smartSqlMapper)
		{
			Log.Logger.Debug($"NativeConfigLoader Load: { _smartSqlOptions.SqlMapperPath} Starting");

			var config = new SmartSqlMapConfig
			{
				Path = _smartSqlOptions.SqlMapperPath,
				SmartSqlMapper = smartSqlMapper,
				SmartSqlMaps = new List<SmartSqlMap>(),
				SmartSqlMapSources = new List<SmartSqlMapSource>
				{
					new SmartSqlMapSource
					{
						Path = _smartSqlOptions.SqlMapperPath,
						Type = SmartSqlMapSource.ResourceType.Directory
					}
				},
				Database = new Database
				{
					DbProvider = new DbProvider
					{
						ParameterPrefix = _smartSqlOptions.ParameterPrefix,
						Name = _smartSqlOptions.DbProviderFactory.GetType().Name,
						Type = _smartSqlOptions.DbProviderFactory.GetType().AssemblyQualifiedName
					},
					WriteDataSource = new WriteDataSource
					{
						ConnectionString = _smartSqlOptions.ConnectionString,
						Name = _smartSqlOptions.LoggingName
					},
					ReadDataSources = new List<ReadDataSource>
					{
						new ReadDataSource
						{
							ConnectionString = _smartSqlOptions.ConnectionString,
							Name = _smartSqlOptions.LoggingName,
							Weight = 1,
						}
					},
				},
				Settings = new Settings
				{
					ParameterPrefix = _smartSqlOptions.ParameterPrefix,
					IsWatchConfigFile = true
				},
			};

			if (_smartSqlOptions.UseManifestResource)
			{
				foreach (var assembly in _assemblies)
				{
					foreach (var sourceName in assembly.names)
					{
						LoadManifestSmartSqlMaps(config, assembly.assembly, sourceName);
					}
				}
			}
			else
			{
				foreach (var sqlmapSource in config.SmartSqlMapSources)
				{
					switch (sqlmapSource.Type)
					{
						case SmartSqlMapSource.ResourceType.File:
							{
								LoadSmartSqlMaps(config, sqlmapSource.Path);
								break;
							}
						case SmartSqlMapSource.ResourceType.Directory:
							{
								var childSqlmapSources = Directory.EnumerateFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sqlmapSource.Path), "*.xml");
								foreach (var childSqlmapSource in childSqlmapSources)
								{
									LoadSmartSqlMaps(config, childSqlmapSource);
								}
								break;
							}
						default:
							{
								Log.Logger.Debug($"LocalFileConfigLoader unknow SmartSqlMapSource.ResourceType:{sqlmapSource.Type}.");
								break;
							}
					}
				}
			}
			Log.Logger.Debug($"LocalFileConfigLoader Load: { _smartSqlOptions.SqlMapperPath} End");
			smartSqlMapper.LoadConfig(config);

			if (config.Settings.IsWatchConfigFile)
			{
				Log.Logger.Debug($"LocalFileConfigLoader Load Add WatchConfig: { _smartSqlOptions.SqlMapperPath} Starting.");
				WatchConfig(smartSqlMapper);
				Log.Logger.Debug($"LocalFileConfigLoader Load Add WatchConfig: { _smartSqlOptions.SqlMapperPath} End.");
			}
			return config;
		}

		private void LoadSmartSqlMaps(SmartSqlMapConfig config, string sqlmapSourcePath)
		{
			Log.Logger.Debug($"LoadSmartSqlMap Load: {sqlmapSourcePath}");
			var sqlmapStream = LoadConfigStream(sqlmapSourcePath);
			var sqlmap = LoadSmartSqlMap(sqlmapStream, config);
			config.SmartSqlMaps.Add(sqlmap);
		}

		public ConfigStream LoadConfigStream(string path)
		{
			var configStream = new ConfigStream
			{
				Path = path,
				Stream = FileLoader.Load(path)
			};
			return configStream;
		}

		private void LoadManifestSmartSqlMaps(SmartSqlMapConfig config, Assembly assembly, string name)
		{
			var configStream = new ConfigStream
			{
				Path = name,
				Stream = assembly.GetManifestResourceStream(name)
			};
			var sqlmap = LoadSmartSqlMap(configStream, config);
			config.SmartSqlMaps.Add(sqlmap);
		}

		/// <summary>
		/// 监控配置文件-热更新
		/// </summary>
		/// <param name="smartSqlMapper"></param>
		private void WatchConfig(ISmartSqlMapper smartSqlMapper)
		{
			var config = smartSqlMapper.SqlMapConfig;

			#region SmartSqlMapConfig File Watch

			Log.Logger.Debug($"LocalFileConfigLoader Watch SmartSqlMapConfig: {config.Path} .");
			var cofigFileInfo = FileLoader.GetInfo(config.Path);
			FileWatcherLoader.Instance.Watch(cofigFileInfo, () =>
			{
				Thread.Sleep(DelayedLoadFile);
				lock (this)
				{
					try
					{
						Log.Logger.Debug($"LocalFileConfigLoader Changed ReloadConfig: {config.Path} Starting");
						Load(config.Path, smartSqlMapper);
						Log.Logger.Debug($"LocalFileConfigLoader Changed ReloadConfig: {config.Path} End");
					}
					catch (Exception ex)
					{
						Log.Logger.Error(ex, ex.Message);
					}
				}
			});

			#endregion SmartSqlMapConfig File Watch

			#region SmartSqlMaps File Watch

			foreach (var sqlmap in config.SmartSqlMaps)
			{
				#region SqlMap File Watch

				Log.Logger.Debug($"LocalFileConfigLoader Watch SmartSqlMap: {sqlmap.Path} .");
				var sqlMapFileInfo = FileLoader.GetInfo(sqlmap.Path);
				FileWatcherLoader.Instance.Watch(sqlMapFileInfo, () =>
				{
					Thread.Sleep(DelayedLoadFile);
					lock (this)
					{
						try
						{
							Log.Logger.Debug($"LocalFileConfigLoader Changed Reload SmartSqlMap: {sqlmap.Path} Starting");
							var sqlmapStream = LoadConfigStream(sqlmap.Path);
							var newSqlmap = LoadSmartSqlMap(sqlmapStream, config);
							sqlmap.Scope = newSqlmap.Scope;
							sqlmap.Statements = newSqlmap.Statements;
							sqlmap.Caches = newSqlmap.Caches;
							config.ResetMappedStatements();
							smartSqlMapper.CacheManager.ResetMappedCaches();
							Log.Logger.Debug($"LocalFileConfigLoader Changed Reload SmartSqlMap: {sqlmap.Path} End");
						}
						catch (Exception ex)
						{
							Log.Logger.Error(ex, ex.Message);
						}
					}
				});

				#endregion SqlMap File Watch
			}

			#endregion SmartSqlMaps File Watch
		}
	}
}