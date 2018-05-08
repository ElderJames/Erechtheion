using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace DNIC.Erechtheion.Core.Extensions
{
	public static class AutoMapperExtensions
	{
		private static bool _initialized = false;
		private static readonly object Locker = new object();

		static AutoMapperExtensions()
		{
			Initialize();
		}

		public static void Initialize()
		{
			if (!_initialized)
			{
				lock (Locker)
				{
					if (!_initialized)
					{
						Mapper.Initialize(cfg =>
						{
							cfg.ForAllMaps((typeMap, mappingExpr) =>
							{
								var ignoredPropMaps = typeMap.GetPropertyMaps();
								foreach (var map in ignoredPropMaps)
								{
									var sourcePropInfo = map.SourceMember as PropertyInfo;
									if (sourcePropInfo == null) continue;

									if (sourcePropInfo.PropertyType != map.DestinationPropertyType)
										map.Ignored = true;
								}
								mappingExpr.ForAllMembers(opt =>
								{
									if (ignoredPropMaps.All(p => opt.DestinationMember.Name != p.SourceMember.Name))
									{
										opt.Ignore();
									}
								});
							});
						});
						_initialized = true;
					}
				}
			}
		}

		/// <summary>
		/// 对象到对象
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static T MapTo<T>(this object obj)
		{
			if (obj == null) return default(T);

			return Mapper.Map<T>(obj);
		}

		/// <summary>
		/// 集合到集合
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static List<T> MapTo<T>(this IEnumerable obj)
		{
			if (obj == null) throw new ArgumentNullException();

			return Mapper.Map<List<T>>(obj);
		}
	}
}