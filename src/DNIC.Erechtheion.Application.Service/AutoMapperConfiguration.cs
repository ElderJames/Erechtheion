using AutoMapper;
using DNIC.Erechtheion.Application.Topic.Dto;

namespace DNIC.Erechtheion.Application.Service
{
	public class AutoMapperConfiguration
	{
		public static void CreateMap()
		{
			Mapper.Initialize(config =>
			{
				config.CreateMap<Domain.Entities.Topic, TopicOutput>();
			});
		}
	}
}