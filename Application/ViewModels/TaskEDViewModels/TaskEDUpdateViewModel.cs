using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.ViewModels.TaskEDViewModels
{
    public class TaskEDUpdateViewModel
    {
        public int TaskStatus { get; set; }
        [JsonIgnore]
        public DateTime? CompleteDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public DateTime? TaskUpdateAt { get; set; } = DateTime.Now;

        public string? TaskUpdateDescription { get; set; }
    }
}
