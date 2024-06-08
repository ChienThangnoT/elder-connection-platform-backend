using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.ElderInformationViewModels;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class ElderInformationService : IElderInformationService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ElderInformationService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<BaseResponseModel> GetElderInformationByChildIdAsync(string childId)
		{
			var elderInformation = await _unitOfWork.ElderInformationRepo.GetElderInformationByChildIdAsync(childId);

			return new SuccessResponseModel
			{
				Status = StatusCodes.Status200OK,
				Message = "Elder information retrieved successfully",
				Result = elderInformation
			};
		}

		public async Task<BaseResponseModel> UpdateElderInformationAsync(int Id, ElderInformationUpdateModel elderInformationUpdateModel)
		{
			var elderInformation = await _unitOfWork.ElderInformationRepo.GetByIdAsync(Id);

			if (elderInformation == null)
			{
				return new FailedResponseModel
				{
					Status = StatusCodes.Status404NotFound,
					Message = "Elder information not found",
					Errors = "Elder information not found"
				};
			}

			_mapper.Map(elderInformationUpdateModel, elderInformation);

			_unitOfWork.ElderInformationRepo.Update(elderInformation);

			try
			{
				await _unitOfWork.SaveChangesAsync();
			}
			catch (RequestFailedException ex)
			{
				return new FailedResponseModel
				{
					Status = StatusCodes.Status500InternalServerError,
					Message = "Internal server error",
					Errors = ex.Message
				};
			}

			return new SuccessResponseModel
			{
				Status = StatusCodes.Status200OK,
				Message = "Elder information updated successfully",
				Result = elderInformation
			};
		}
	}
}
