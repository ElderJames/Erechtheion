using System;
using DNIC.Erechtheion.Application.Dto.Reply;
using DNIC.Erechtheion.Core.DtoBase;
using DNIC.Erechtheion.Core.Services.Dto;

namespace DNIC.Erechtheion.Application
{
	public interface IReplyAplicationService
	{
		ApiResult<Guid> Create(CreateReplyDto request);

		ApiResult<bool> Change(ChangeReplyDto request);

		ApiResult<bool> Close(CloseReplyDto request);

		ApiResult<ReplyDto> GetById(Guid id);

		ApiResult<PaginationQueryResult<ReplyDto>> Search(ReplyCondition request);
	}
}