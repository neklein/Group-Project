using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonster.Data_CLW
{
    public class Post
    {
        public int PostID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? ExpDate { get; set; }

        public List<Comment>Comments { get; set; }
    }
}
