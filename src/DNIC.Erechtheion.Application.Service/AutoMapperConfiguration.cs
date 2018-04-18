using AutoMapper;
using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.Domain.Aggregates;

namespace DNIC.Erechtheion.Application.Service
{
	public class AutoMapperConfiguration
	{
		public static void CreateMap()
		{
			Mapper.Initialize(config =>
			{
				config.CreateMap<Topic, TopicOutput>();
			});
		}
	}
}