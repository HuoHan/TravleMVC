using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvcTravel.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public string TrueName { get; set; }
        public int Phone { get; set; }
        public string Remark { get; set; }
    }
}