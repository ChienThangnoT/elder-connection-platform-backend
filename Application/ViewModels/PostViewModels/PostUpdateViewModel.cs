using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.ViewModels.PostViewModels
{
    public class PostUpdateViewModel
    {
        public int ServiceId { get; set; }
        public int AddressId { get; set; }
        public bool? IsPriorityFavoriteConnector { get; set; }
        public string? PostDescription { get; set; }
        public string? Title { get; set; }
        public TimeOnly StartTime { get; set; }
        [JsonIgnore]
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        [JsonIgnore]
        public float Price { get; set; }
        [JsonIgnore]
        public float SalaryAfterWork { get; set; }
    }
}
