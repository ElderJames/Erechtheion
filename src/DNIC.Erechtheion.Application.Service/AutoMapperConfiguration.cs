using AutoMapper;
using DNIC.Erechtheion.Application.Dto;

namespace DNIC.Erechtheion.Application.Service
{
	public class AutoMapperConfiguration
	{
		public static void CreateMap()
		{
			Mapper.Initialize(config =>
			{
				config.CreateMap<Domain.Topic.Topic, TopicOutput>();
			});
		}
	}
}