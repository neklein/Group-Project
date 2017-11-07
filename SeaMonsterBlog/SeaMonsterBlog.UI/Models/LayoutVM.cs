using SeaMonsterBlog.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeaMonsterBlog.UI.Models
{
    public class LayoutVM
    {
        public List<Post> StaticPosts { get; set; }
        public List<Category> Categories { get; set; }
    }
}