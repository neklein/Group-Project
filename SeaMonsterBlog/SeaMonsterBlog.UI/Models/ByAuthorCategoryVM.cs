﻿using SeaMonsterBlog.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeaMonsterBlog.UI.Models
{
    public class ByAuthorCategoryVM : LayoutVM
    {
        List<Post> Posts { get; set; }
    }
}