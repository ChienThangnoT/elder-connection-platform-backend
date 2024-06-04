using Domain.Enums.PostEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.ViewModels.PostViewModels
{
    public class PostCreateViewModel
    {
        public int ServiceId { get; set; }
        [JsonIgnore]
        public int JobScheduleId { get; set; }
        public string? CustomerId { get; set; }
        public int AddressId { get; set; }
        public bool? IsPriorityFavoriteConnector { get; set; }
        public string? PostDescription { get; set; }
        public string? Title { get; set; }
        [JsonIgnore]
        public int PostStatus { get; set; }
        public TimeOnly StartTime { get; set; }
        [JsonIgnore]
        public DateTime CreateAt { get; set; } = DateTime.Now;
        [JsonIgnore]
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        [JsonIgnore]
        public float Price { get; set; }
        [JsonIgnore]
        public float SalaryAfterWork { get; set; } 
    }
}
