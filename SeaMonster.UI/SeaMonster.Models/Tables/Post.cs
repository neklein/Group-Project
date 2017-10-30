using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonster.Models.Tables
{
    public class Post
    {
        public int PostId { get; set; }
        //added by
        public int UserId { get; set; }
        public DateTime ExpDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ToPostDate { get; set; }
        public bool IsPublished { get; set; }
    }
}
