using AutoMapper;
using DNIC.Erechtheion.Core.Domain;
using DNIC.Erechtheion.Core.DtoBase;
using DNIC.Erechtheion.Core.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DNIC.Erechtheion.Core.Linq.Extensions
{
	/// <summary>
	/// Some useful extension methods for <see cref="IQueryable{T}"/>.
	/// </summary>
	public static class QueryableExtensions
	{
		public static PaginationQueryResult<TDto> PageList<TEntity, TKey, TDto, TProperty>(this IQueryable<TEntity> dbSet, PaginationQuery input,
					Expression<Func<TEntity, bool>> where = null,
					Expression<Func<TEntity, TKey>> orderBy = null, bool orderByDesc = false, Expression<Func<TEntity, TProperty>> navigationPropertyPath = null)
			where TEntity : class, IEntity<TKey> where TDto : IEntityDto
		{

			IQueryable<TEntity> entities = dbSet.AsQueryable();
			if (where != null)
			{
				entities = entities.Where(where);
			}

			var totalCount = entities.Count();

			if (orderBy == null)
			{
				if (orderByDesc)
				{
					entities = entities.OrderByDescending(e => e.Id).Skip((input.Page - 1) * input.PageSize).Take(input.PageSize);
				}
				else
				{
					entities = entities.Skip((input.Page - 1) * input.PageSize).Take(input.PageSize);
				}
			}
			else
			{
				if (orderByDesc)
				{
					entities = entities.OrderByDescending(orderBy).Skip((input.Page - 1) * input.PageSize).Take(input.PageSize);
				}
				else
				{
					entities = entities.OrderBy(orderBy).Skip((input.Page - 1) * input.PageSize).Take(input.PageSize);
				}
			}

			//if (navigationPropertyPath != null)
			//{
			//	entities = entities.Include(navigationPropertyPath);
			//}

			var page = input.Page;
			var pageSize = input.PageSize;
			var data = (IEnumerable<TDto>)Mapper.Map(entities, typeof(IEnumerable<TEntity>), typeof(IEnumerable<TDto>));
			return new PaginationQueryResult<TDto>(page, pageSize, totalCount, data);
		}
	}
}
