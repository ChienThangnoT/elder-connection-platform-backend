using Application.Exceptions;
using Application.IServices;
using Application.ViewModels.JobScheduleViewModels;
using AutoMapper;
using Domain.Models;
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
    }
}
