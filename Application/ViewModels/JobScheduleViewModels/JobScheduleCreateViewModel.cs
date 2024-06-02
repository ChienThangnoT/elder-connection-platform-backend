using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.JobScheduleViewModels
{
    public class JobScheduleCreateViewModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Description { get; set; }

        public string? LocationWork { get; set; }

        public float TaskProcess { get; set; }

        public bool OnTask { get; set; }
    }
}
