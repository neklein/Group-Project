using SeaMonsterBlog.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeaMonsterBlog.UI.Models
{
    public class DetailVM : LayoutVM
    {
        public Post Post { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Reply> Replies { get; set; }
    }
}