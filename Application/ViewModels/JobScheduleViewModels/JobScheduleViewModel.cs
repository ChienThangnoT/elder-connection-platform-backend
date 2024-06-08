using Application.ViewModels.TaskEDViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.JobScheduleViewModels
{
    public class JobScheduleViewModel
    {
        public int JobScheduleId { get; set; }
        public string? ConnectorId { get; set; }
        public string? connectorFirstName { get; set; }
        public string? connectorLastName { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Description { get; set; }
        public string? LocationWork { get; set; }
        public string? ListDayWork { get; set; }

        public float TaskProcess { get; set; }

        public bool OnTask { get; set; }
        public List<TaskEDViewModel> Tasks { get; set; }
    }
}
