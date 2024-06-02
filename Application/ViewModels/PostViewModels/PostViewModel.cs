using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.PostViewModels
{
    public class PostViewModel
    {
        public int PostId { get; set; }

        public int ServiceId { get; set; }

        public int JobScheduleId { get; set; }

        public string? CustomerId { get; set; }

        public int AddressId { get; set; }

        public bool? IsPriorityFavoriteConnector { get; set; }

        public string? PostDescription { get; set; }

        public string? Title { get; set; }

        public int PostStatus { get; set; }

        public TimeOnly StartTime { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public float Price { get; set; }

        public float SalaryAfterWork { get; set; }
    }
}
