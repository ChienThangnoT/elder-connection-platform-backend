using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.ViewModels.JobScheduleViewModels
{
    public class JobScheduleProcessViewModel
    {
        public int jobScheduleId { get; set; }
        public int totalTasks { get; set; }
        public int totalTasksDone { get;set; }
        public int processPercentage { get; set; }

    }
}
