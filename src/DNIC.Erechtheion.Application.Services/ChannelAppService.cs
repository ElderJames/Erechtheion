using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.Core.Domain.Uow;
using DNIC.Erechtheion.Domain.Repositories;

namespace DNIC.Erechtheion.Application.Services
{
	public class ChannelAppService : IChannelAppService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IChannelRepository channelRepository;

		public ChannelAppService(IUnitOfWork unitOfWork, IChannelRepository channelRepository)
		{
			this.unitOfWork = unitOfWork;
			this.channelRepository = channelRepository;
		}

		public async Task CreateChannelAsync(CreateChannelDto input)
		{
			////验证
			////Assert.IsFalse(this.channelRepository.ExistsName(input.Name), "栏目名称已存在！");
			//Channel parentChannel = input.ParentId == 0 ? null : this.unitOfWork.Resolve<Channel>(input.ParentId);
			//this.unitOfWork.RegisterAdd(Mapper.Map<Channel>(input));
			//await this.unitOfWork.UnitedCommitAsync();
		}
	}
}