using SeaMonsterBlog.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeaMonsterBlog.UI.Models
{
    public class DashboardVM : LayoutVM
    {
        public List<Post> PostsUnderReview { get; set; }
        public List<Post> PostsPendingComments { get; set; }
    }
}