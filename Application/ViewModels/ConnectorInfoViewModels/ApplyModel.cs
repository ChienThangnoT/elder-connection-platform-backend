﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ConnectorInfoViewModels
{
    public class ApplyModel
    {
        public int ConnectorInforId { get; set; }

        public string? SocialNumber { get; set; }

        public DateTime SendDate { get; set; }

        public string? CccdFrontImg { get; set; }

        public string? CccdBehindImg { get; set; }

        public string? SyllFrontImg { get; set; }

        public string? SyllBehindImg { get; set; }

        public string? GxnhkImg { get; set; }
    }
}
