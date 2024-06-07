using Application.Common;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.JobScheduleViewModels;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class JobScheduleService : IJobScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region CreateJobScheduleAsync
        public async Task<JobScheduleViewModel> CreateJobScheduleAsync(JobScheduleCreateViewModel jobScheduleCreateViewModel)
        {
            var jobSchedule = _mapper.Map<JobSchedule>(jobScheduleCreateViewModel);
            await _unitOfWork.JobScheduleRepo.AddAsync(jobSchedule);
            await _unitOfWork.SaveChangesAsync();
            var jobScheduleResult = _mapper.Map<JobScheduleViewModel>(jobSchedule);
            return jobScheduleResult;
        }
        #endregion

        #region UpdateJobSchedule
        public async Task UpdateJobSchedule(
            int jobScheduleId,
            JobScheduleUpdateViewModel jobScheduleUpdateViewModel)
        {
            var jobSchedule =  await _unitOfWork.JobScheduleRepo
                .GetByIdAsync(jobScheduleId)
                ?? throw new NotExistsException(); 

            _mapper.Map(jobScheduleUpdateViewModel, jobSchedule);
            _unitOfWork.JobScheduleRepo.Update(jobSchedule);
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region DeleteJobSchedule
        public async Task DeleteJobSchedule(JobSchedule jobSchedule)
        {
            _unitOfWork.JobScheduleRepo.Remove(jobSchedule);
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region GetAllJobSchedules
        public async Task<IEnumerable<BaseResponseModel>> GetAllJobSchedulesAsync()
        {
            var jobSchedules = await _unitOfWork.JobScheduleRepo.GetAllAsync();
            var result = _mapper.Map<IEnumerable<JobScheduleViewModel>>(jobSchedules);
            return new List<BaseResponseModel>
            {
                new SuccessResponseModel
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Get job schedules successfully",
                    Result = result
                }
            };
        }
        #endregion

        #region GetJobScheduleById
        public async Task<BaseResponseModel> GetJobScheduleByIdAsync(int id)
        {
            var jobSchedule = await _unitOfWork.JobScheduleRepo.GetJobScheduleByIdWithInclude(id);
            var result = _mapper.Map<JobScheduleViewModel>(jobSchedule);
            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Get job schedule successfully",
                Result = result
            };
        }
        #endregion

        #region GetJobScheduleByConnectorId
        public async Task<BaseResponseModel> GetJobScheduleByConnectorIdAsync(
            string connectorId, int pageIndex = 0, int pageSize = 10)
        {
            // Check if connector is exist
            var isExistConnector = await _unitOfWork.AccountRepo.GetAccountByIdAsync(connectorId)
                ?? throw new NotExistsException(); 
            // Get all job schedule claimed by connector
            var jobSchedules = await _unitOfWork.JobScheduleRepo.GetJobScheduleListByConnectorIdAsync(
                               connectorId, pageIndex, pageSize);
            // Map to JobScheduleViewModel
            var result = _mapper.Map<Pagination<JobScheduleViewModel>>(jobSchedules);

            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Get all job schedule by connector id success",
                Result = result
            };
        }
        #endregion
    }
}
