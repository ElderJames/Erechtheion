using AutoMapper;
using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.Core.RepositoryBase;
using DNIC.Erechtheion.Core.Transaction;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNIC.Erechtheion.Application.Service
{
	public class ChannelApplicationService : IChannelApplicationService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IChannelRepository channelRepository;

		public ChannelApplicationService(IUnitOfWork unitOfWork, IChannelRepository channelRepository)
		{
			this.unitOfWork = unitOfWork;
			this.channelRepository = channelRepository;
		}

		public async Task CreateChannelAsync(CreateChannelDto input)
		{
			//验证
			//Assert.IsFalse(this.channelRepository.ExistsName(input.Name), "栏目名称已存在！");
			Channel parentChannel = input.ParentId == 0 ? null : this.unitOfWork.Resolve<Channel>(input.ParentId);
			this.unitOfWork.RegisterAdd(Mapper.Map<Channel>(input));
			await this.unitOfWork.UnitedCommitAsync();
		}
	}
}
