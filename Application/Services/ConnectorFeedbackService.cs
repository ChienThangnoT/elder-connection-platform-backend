using Application.Common;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.ConnectorFeedbackViewModels;
using AutoMapper;
using Infracstructures.Mappers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class ConnectorFeedbackService : IConnectorFeedbackService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ConnectorFeedbackService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<BaseResponseModel> GetFeedbackViewModelAsync(string connectorId)
		{
			var check = await _unitOfWork.AccountRepo.GetAccountByIdAsync(connectorId);
			if (check == null)
			{
				throw new NotExistsException();
			}
			var feedbacks = await _unitOfWork.ConnectorFeedbackRepo.GetFeedbackByConnectorIdAsync(connectorId);

			var feedbackViewModel = _mapper.Map<Pagination<ConnectorFeedbackViewModel>>(feedbacks);
			var response = new SuccessResponseModel
			{
				Status = StatusCodes.Status200OK,
				Message = "Feedbacks retrieved successfully",
				Result = feedbackViewModel
			};

			return response;
		}
	}
}
