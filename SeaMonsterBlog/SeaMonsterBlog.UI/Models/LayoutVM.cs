using SeaMonsterBlog.Models.ShortList;
using SeaMonsterBlog.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeaMonsterBlog.UI.Models
{
    public class LayoutVM
    {
        public List<StaticPageShort> StaticShortList { get; set; }
        public List<Category> Categories { get; set; }
    }
}