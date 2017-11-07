using SeaMonsterBlog.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeaMonsterBlog.UI.Models
{
    public class ByAuthorCategoryVM : LayoutVM
    {
        public List<Post> Posts { get; set; }
        public Category Category { get; set; }

        public List<SelectListItem> CategoriesSelectList { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem> AuthorsSelectList { get; set; }
        public string AuthorName { get; set; }
    }
}