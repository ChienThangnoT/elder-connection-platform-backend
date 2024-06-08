using Application.Common;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.ServiceFeedbackViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class ServiceFeedbackService : IServiceFeedbackService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ServiceFeedbackService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<BaseResponseModel> GetServiceFeedbackViewModelAsync(int serviceFeedbackId)
		{
			var check = await _unitOfWork.ServiceFeedbackRepo.GetByIdAsync(serviceFeedbackId);
			if (check == null)
			{
				throw new NotExistsException();
			}
			var feedbacks = await _unitOfWork.ServiceFeedbackRepo.GetFeedbackByServiceIdAsync(serviceFeedbackId);

			var feedbackViewModel = _mapper.Map<Pagination<ServiceFeedbackViewModel>>(feedbacks);
			var response = new SuccessResponseModel
			{
				Status = StatusCodes.Status200OK,
				Message = "Service Feedbacks retrieved successfully",
				Result = feedbackViewModel
			};

			return response;
		}
	}
}
