using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonsterBlog.Models.Tables
{
    public class Hashtag
    {
        public int HashtagID { get; set; }
        public string HashtagName { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
