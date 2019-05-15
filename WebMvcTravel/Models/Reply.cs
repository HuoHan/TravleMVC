using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMvcTravel.Models
{
    public class Reply
    {
        public int ReplyId { get; set; }
        public string ReplayRemark { get; set; }
        public int Comment_Id { get; set; }
    }
}
