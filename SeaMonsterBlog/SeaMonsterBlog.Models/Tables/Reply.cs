using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonsterBlog.Models.Tables
{
    public class Reply
    {
        public int ReplyID { get; set; }
        public int CommentID { get; set; }
        public string ReplyName { get; set; }
        public DateTime ReplyDate { get; set; }
        public string ReplyText { get; set; }
        public bool IsShown { get; set; }
    }
}
