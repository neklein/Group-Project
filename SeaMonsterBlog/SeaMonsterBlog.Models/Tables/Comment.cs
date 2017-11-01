using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonsterBlog.Models.Tables
{
    public class Comment
    {

        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string CommenterName { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }
        public bool IsShown { get; set; }
        public List<Reply> Replies { get; set; }

    }
}
