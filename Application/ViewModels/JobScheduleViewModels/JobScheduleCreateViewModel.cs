using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.ViewModels.JobScheduleViewModels
{
    public class JobScheduleCreateViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public string? LocationWork { get; set; }
        public string? ListDayWork { get; set; }
        [JsonIgnore]
        public float TaskProcess { get; set; } = 0;
        [JsonIgnore]
        public bool OnTask { get; set; } = false;
    }
}
