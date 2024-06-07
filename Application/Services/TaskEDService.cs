using Application.Common;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.PostViewModels;
using Application.ViewModels.TaskEDViewModels;
using AutoMapper;
using Domain.Enums.TaskEnums;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TaskEDService : ITaskEDService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskEDService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region CreateTaskED
        public async Task CreateTaskED(TaskEDCreateViewModel taskEDCreateViewModel)
        {
            var task = _mapper.Map<TaskED>(taskEDCreateViewModel);
            await _unitOfWork.TaskEDRepo.AddAsync(task);
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region DeleteTaskED
        public async Task DeleteTaskED(TaskED taskED)
        {
            _unitOfWork.TaskEDRepo.Remove(taskED);
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion

        // Delete this method
        //#region GetTaskEDListByConnectorIdAsync
        //public async Task<BaseResponseModel> GetTaskEDListByConnectorIdAsync(
        //    string connector, int pageIndex = 0, int pageSize = 10)
        //{
        //    // Check if connector is exist
        //    var isExistConnector = await _unitOfWork.AccountRepo.GetAccountByIdAsync(connector) 
        //        ?? throw new NotExistsException();
        //    // Get all task claimed by connector 
        //    var taskEDs = await _unitOfWork.TaskEDRepo.GetTaskEDListByConnectorIdAsync(
        //                       connector, pageIndex, pageSize);
        //    // Map to TaskEDViewModel
        //    var result = _mapper.Map<Pagination<TaskEDViewModel>>(taskEDs);
        //    return new SuccessResponseModel
        //    {
        //        Status = StatusCodes.Status200OK,
        //        Message = "Get all post by customer id success",
        //        Result = result
        //    };
        //}
        //#endregion

        #region GetTaskEDByIdAsync
        public async Task<BaseResponseModel> GetTaskEDByIdAsync(int taskEDId)
        {
            var taskED = await _unitOfWork.TaskEDRepo.GetByIdAsync(taskEDId) ?? throw new NotExistsException();
            var result = _mapper.Map<TaskEDViewModel>(taskED);
            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Get taskED detail success",
                Result = result
            };
        }
        #endregion

        #region GetTaskEDListByJobScheduleIdAsync
        public async Task<BaseResponseModel> GetTaskEDListByJobScheduleIdAsync(
            int jobScheduleId, int pageIndex = 0, int pageSize = 10)
        {
            // Check if job schedule is exist
            var isExistJobSchedule = await _unitOfWork.JobScheduleRepo.GetByIdAsync(jobScheduleId) 
                ?? throw new NotExistsException();
            // Get all task of job schedule
            var taskEDs = await _unitOfWork.TaskEDRepo.GetTaskEDListByJobScheduleIdAsync(
                                              jobScheduleId, pageIndex, pageSize);
            // Map to TaskEDViewModel
            var result = _mapper.Map<Pagination<TaskEDViewModel>>(taskEDs);

            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Get all task by job schedule id success",
                Result = result
            };
        }
        #endregion

        #region Update TaskED Status
        public async Task<BaseResponseModel> UpdateTaskEDStatus(int id, TaskEDUpdateViewModel taskUpdateViewModel)
        {
            var taskED = await _unitOfWork.TaskEDRepo.GetByIdAsync(id) 
                ?? throw new NotExistsException();
            _mapper.Map(taskUpdateViewModel, taskED);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<TaskEDViewModel>(taskED);
            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Update taskED status success",
                Result = result
            };
        }
        #endregion
    }
}
