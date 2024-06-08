using Application.IServices;
using Application.ResponseModels;
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
	}
}
