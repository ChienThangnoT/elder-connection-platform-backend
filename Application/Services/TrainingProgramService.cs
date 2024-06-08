using Application.Common;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.TrainingProgramViewModels;
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
	public class TrainingProgramService : ITrainingProgramService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public TrainingProgramService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<BaseResponseModel> AddTrainingProgramAsync(TrainingProgramAddModel trainingProgramAddModel)
		{
			var trainingProgram = _mapper.Map<TrainingProgram>(trainingProgramAddModel);
			await _unitOfWork.TrainingProgramRepo.AddAsync(trainingProgram);
			await _unitOfWork.SaveChangesAsync();

			var response = new SuccessResponseModel
			{
				Status = StatusCodes.Status202Accepted,
				Message = "Training Program added successfully",
				Result = trainingProgramAddModel
			};

			return response;
		}

		public async Task<BaseResponseModel> GetAllTrainingProgramAsync(int pageIndex, int pageSize)
		{
			var trainingProgram = await _unitOfWork.TrainingProgramRepo.GetAllTrainingProgramAsync(pageIndex, pageSize);
			var trainingProgramViewModels = _mapper.Map<Pagination<TrainingProgramViewModel>>(trainingProgram);
			var response = new SuccessResponseModel
			{
				Status = StatusCodes.Status200OK,
				Message = "Training Program retrieved successfully",
				Result = trainingProgramViewModels
			};

			return response;
		}

		public async Task<BaseResponseModel> UpdateTrainingProgramAsync(int trainingProgramId, TrainingProgramUpdateModel trainingProgramUpdateModel)
		{
			var trainingProgram = await _unitOfWork.TrainingProgramRepo.GetByIdAsync(trainingProgramId);

			if (trainingProgram == null)
			{
				var errorResponse = new FailedResponseModel
				{
					Status = StatusCodes.Status404NotFound,
					Message = "Training Program not found"
				};

				return errorResponse;
			}

			_mapper.Map(trainingProgramUpdateModel, trainingProgram);

			_unitOfWork.TrainingProgramRepo.Update(trainingProgram);
			await _unitOfWork.SaveChangesAsync();

			var response = new SuccessResponseModel
			{
				Status = StatusCodes.Status200OK,
				Message = "Training Program updated successfully",
				Result = trainingProgram
			};

			return response;
		}

		public async Task<BaseResponseModel> RemoveTrainingProgramAsync(int trainingProgramId)
		{
			var trainingProgram = await _unitOfWork.TrainingProgramRepo.GetByIdAsync(trainingProgramId);
			if (trainingProgram == null)
			{
				var errorResponse = new FailedResponseModel
				{
					Status = StatusCodes.Status404NotFound,
					Message = "Training Program not found"
				};
				return errorResponse;
			}
			_unitOfWork.TrainingProgramRepo.Remove(trainingProgram);
			await _unitOfWork.SaveChangesAsync();
			var response = new SuccessResponseModel
			{
				Status = StatusCodes.Status200OK,
				Message = "Training Program removed successfully"
			};
			return response;
		}

        public async Task<BaseResponseModel> GetTrainingProgramDetailAsync(int trainingProgramId)
        {
            var trainingProgram = await _unitOfWork.TrainingProgramRepo.GetByIdAsync(trainingProgramId) ?? throw new NotExistsException();
			var result = _mapper.Map<TrainingProgramViewModel>(trainingProgram);
			return new SuccessResponseModel
			{
				Status = StatusCodes.Status200OK,
				Message = "Get training program detail success",
				Result = result
			};
        }
    }
}
