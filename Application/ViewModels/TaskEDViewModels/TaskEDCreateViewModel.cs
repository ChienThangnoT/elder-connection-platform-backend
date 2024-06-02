using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.TaskEDViewModels
{
    public class TaskEDCreateViewModel
    {
        public int TaskId { get; set; }

        public int JobScheduleId { get; set; }

        public string? ConnectorId { get; set; }

        public DateTime WorkDateAt { get; set; }

        public int TaskStatus { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime CompleteDate { get; set; }

        public DateTime TaskUpdateAt { get; set; }

        public string? TaskUpdateDescription { get; set; }
    }
}
