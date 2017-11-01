using SeaMonsterBlog.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeaMonsterBlog.UI.Models
{
    public class HomeVM : LayoutVM
    {
        public List<Post> Posts { get; set; }
    }
}