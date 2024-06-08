﻿using Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
	public interface IServiceFeedbackService
	{
		Task<BaseResponseModel> GetServiceFeedbackViewModelAsync(int serviceFeedbackId);
		Task<BaseResponseModel> GetServiceFeedbackViewModelPaginationAsync(int serviceFeedbackId, int pageIndex, int pageSize);
	}
}
