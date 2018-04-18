using AutoMapper;
using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.Domain.Entities;

namespace DNIC.Erechtheion.Application.Service
{
	public class AutoMapperConfiguration
	{
		public static void CreateMap()
		{
			Mapper.Initialize(config =>
			{
				config.CreateMap<Topic, TopicOutput>();
				config.CreateMap<CreateChannelDto, Channel>();
			});
		}
	}
}