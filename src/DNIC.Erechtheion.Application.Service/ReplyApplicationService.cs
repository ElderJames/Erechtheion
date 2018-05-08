using System;
using System.Linq;
using AutoMapper;
using DNIC.Erechtheion.Application.Dto.Reply;
using DNIC.Erechtheion.Core.DtoBase;
using DNIC.Erechtheion.Core.Services.Dto;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace DNIC.Erechtheion.Application.Service
{
	public class ReplyApplicationService : IReplyAplicationService
	{
		private readonly IReplyRepository replyRepository;
		private readonly ILoggerFactory loggerFactory;

		public ReplyApplicationService(IReplyRepository replyRepository, ILoggerFactory loggerFactory)
		{
			this.replyRepository = replyRepository;
			this.loggerFactory = loggerFactory;
		}

		public ApiResult<Guid> Create(CreateReplyDto request)
		{
			try
			{
				var id = Guid.NewGuid();
				var reply = new Reply(id, request.ContentId, request.TargetId, request.Target, request.UserId, request.ContentType,
					request.Content);

				replyRepository.Create(reply);

				return new ApiResult<Guid>() { Result = id };
			}
			catch (Exception ex)
			{
				loggerFactory.CreateLogger<ReplyApplicationService>().LogError("创建回复时异常", ex);
				return new ApiResult<Guid>() { Status = ResultStatus.Exception, Message = ex.Message };
			}
		}

		public ApiResult<bool> Change(ChangeReplyDto request)
		{
			try
			{
				var reply = replyRepository.Get(request.ReplyId);

				if (reply == null || reply.UserId != request.UserId)
					return new ApiResult<bool>() { Status = ResultStatus.Fail, Message = "请选择正确的回复" };

				reply.ChangeContent(request.ContentType, request.Content);

				return new ApiResult<bool>() { Status = ResultStatus.Successful, Result = true };
			}
			catch (Exception ex)
			{
				loggerFactory.CreateLogger<ReplyApplicationService>().LogError("修改回复时异常", ex);
				return new ApiResult<bool>() { Status = ResultStatus.Exception, Message = ex.Message };
			}
		}

		public ApiResult<bool> Close(CloseReplyDto request)
		{
			try
			{
				var reply = replyRepository.Get(request.ReplyId);

				if (reply == null || reply.UserId != request.UserId)
					return new ApiResult<bool>() { Status = ResultStatus.Fail, Message = "请选择正确的回复" };

				reply.Close();

				return new ApiResult<bool>() { Status = ResultStatus.Successful, Result = true };
			}
			catch (Exception ex)
			{
				loggerFactory.CreateLogger<ReplyApplicationService>().LogError("关闭回复时异常", ex);
				return new ApiResult<bool>() { Status = ResultStatus.Exception, Message = ex.Message };
			}
		}

		public ApiResult<ReplyDto> GetById(Guid id)
		{
			try
			{
				var reply = replyRepository.Get(id);
				return new ApiResult<ReplyDto>() { Status = ResultStatus.Successful, Result = Mapper.Map<Reply, ReplyDto>(reply) };
			}
			catch (Exception ex)
			{
				loggerFactory.CreateLogger<ReplyApplicationService>().LogError("获取回复时异常", ex);
				return new ApiResult<ReplyDto>() { Status = ResultStatus.Exception, Message = ex.Message };
			}
		}

		public ApiResult<PaginationQueryResult<ReplyDto>> Search(ReplyCondition request)
		{
			try
			{
				var result = replyRepository.Search(request);
				return new ApiResult<PaginationQueryResult<ReplyDto>>()
				{
					Status = ResultStatus.Successful,
					Result = new PaginationQueryResult<ReplyDto>(request.Page, request.PageSize, result.count, result.records.Select(Mapper.Map<Reply, ReplyDto>))
				};
			}
			catch (Exception ex)
			{
				loggerFactory.CreateLogger<ReplyApplicationService>().LogError("获取回复时异常", ex);
				return new ApiResult<PaginationQueryResult<ReplyDto>>() { Status = ResultStatus.Exception, Message = ex.Message };
			}
		}
	}
}