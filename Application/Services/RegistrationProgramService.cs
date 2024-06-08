using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.RegistrationProgramViewModels;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RegistrationProgramService : IRegistrationProgramService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegistrationProgramService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> ApplyTrainingProgram(int trainingProgramId, string connectorId)
        {
            // Check if the training program exists
            var trainingProgram = await _unitOfWork.TrainingProgramRepo.GetByIdAsync(trainingProgramId)
                ?? throw new NotExistsException();

            // Check if the connector exists
            var connector = await _unitOfWork.AccountRepo.GetAccountByIdAsync(connectorId)
                ?? throw new NotExistsException();

            // Check if the registration already exists
            if (await _unitOfWork.RegistrationProgramRepo.ExistsRegistrationAsync(connectorId, trainingProgramId))
                throw new AlreadyExistsException("The connector has already registered for this training program.");

            // Create new registration program
            var newRegistration = new RegistrationProgram
            {
                TraningProgramId = trainingProgramId,
                ConnectorId = connectorId,
                EnrollmentDate = DateTime.Now,
                IsCompleted = false
            };

            await _unitOfWork.RegistrationProgramRepo.AddAsync(newRegistration);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<TrainingProgramApplyViewModel>(newRegistration);

            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Applied to training program successfully.",
                Result = result
            };
        }


    }
    }

