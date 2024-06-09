using Application.Common;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.ConnectorFeedbackViewModels;
using AutoMapper;
using Domain.Models;
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

		public async Task<BaseResponseModel> GetFeedbackViewModelPaginationAsync(string connectorId, int pageIndex, int pageSize)
		{
			var check = await _unitOfWork.AccountRepo.GetAccountByIdAsync(connectorId);
			if (check == null)
			{
				throw new NotExistsException();
			}
			var feedbacks = await _unitOfWork.ConnectorFeedbackRepo
				.GetFeedbackByConnectorIdPaginationAsync(connectorId, pageIndex, pageSize);
			
			var feedbackViewModel = _mapper.Map<Pagination<ConnectorFeedbackViewModel>>(feedbacks);
			if (feedbackViewModel == null)
			{
				throw new NotExistsException();
			}
			var response = new SuccessResponseModel
			{
				Status = StatusCodes.Status200OK,
				Message = "Feedbacks retrieved successfully",
				Result = feedbackViewModel
			};

			return response;
		}

        public async Task<BaseResponseModel> RateConnectorAsync(RateConnectorViewModel rateConnectorViewModel)
        {
            // Check if the feedback already exists
            if (await _unitOfWork.ConnectorFeedbackRepo.ExistsFeedbackAsync(rateConnectorViewModel.TaskId, rateConnectorViewModel.CustomerId, rateConnectorViewModel.ConnectorId))
                throw new AlreadyExistsException("Feedback already exists for this task.");

            // Check if the customer exists
            var customer = await _unitOfWork.AccountRepo.GetAccountByIdAsync(rateConnectorViewModel.CustomerId);
            if (customer == null)
                throw new NotExistsException();

            // Check if the connector exists
            var connector = await _unitOfWork.AccountRepo.GetAccountByIdAsync(rateConnectorViewModel.ConnectorId);
            if (connector == null)
                throw new NotExistsException();

            // Create new feedback
            var feedback = new ConnectorFeedback
            {
                TaskId = rateConnectorViewModel.TaskId,
                CustomerId = rateConnectorViewModel.CustomerId,
                ConnectorId = rateConnectorViewModel.ConnectorId,
                RatingStars = rateConnectorViewModel.RatingStars,
                RatingDate = DateTime.Now,
                IsRatingStatus = true
            };

            await _unitOfWork.ConnectorFeedbackRepo.AddAsync(feedback);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<ConnectorFeedbackViewModel>(feedback);

            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Feedback added successfully.",
                Result = result
            };
        }
    }
}
