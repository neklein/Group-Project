using SeaMonsterBlog.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeaMonsterBlog.UI.Models
{
    public class CreateEditVM 
    {
        List<StaticShortVM> StaticShortList { get; set; }
        List<Category> Categories { get; set; }
        public Post Post { get; set; }
        public List<Image> Images { get; set; }
        public string ImageTitle { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
    }

}