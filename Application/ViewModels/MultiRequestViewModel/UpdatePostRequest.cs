using Application.ViewModels.JobScheduleViewModels;
using Application.ViewModels.PostViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.MultiRequestViewModel
{
    public class UpdatePostRequest
    {
        public PostUpdateViewModel PostUpdateViewModel { get; set; }
        public JobScheduleUpdateViewModel JobScheduleUpdateViewModel { get; set; }
    }
}
