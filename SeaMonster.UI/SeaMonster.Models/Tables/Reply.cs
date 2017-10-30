using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonster.Models.Tables
{
    public class Reply
    {
        public int ReplyId { get; set; }
        public int CommentId { get; set; }
        public string CommenterName { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }
        public bool IsShown { get; set; }
    }
}
