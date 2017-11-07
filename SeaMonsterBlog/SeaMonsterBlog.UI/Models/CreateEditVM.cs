using SeaMonsterBlog.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeaMonsterBlog.UI.Models
{
    public class CreateEditVM : LayoutVM
    {

        public Post Post { get; set; }
        public List<Image> Images { get; set; }
        public string ImageTitle { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
    }
}