using SeaMonsterBlog.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeaMonsterBlog.UI.Models
{
    public class DashboardVM : LayoutVM
    {
        public List<Post> PostsUnderReview { get; set; }
        public List<Post> PostsPendingComments { get; set; }
        public string NewCategory { get; set; }
        public int? DeleteCategory { get; set; }
        public IEnumerable<SelectListItem> CategoryPickList { get; set; }
    }
}