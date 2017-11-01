using SeaMonsterBlog.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeaMonsterBlog.Data;

namespace SeaMonsterBlog.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Create()
        {
            var repo = RepositoryFactory.GetRepository();
            CreateEditVM createEditVM = new CreateEditVM();
            createEditVM.Categories = repo.GetAllCategories();
            
            return View(createEditVM);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreateEditVM createEditVM)
        {
            string fileName;
            if (createEditVM.Post.IsForReview)
            {
                //save all necessary stuff
                return Redirect("Review");
            }
            else if (createEditVM.UploadedFile != null)
            {
                fileName = createEditVM.UploadedFile.FileName;

                if (fileName != null && fileName.Contains(".jpg"))
                {
                    fileName = createEditVM.ImageTitle + ".jpg";
                    if (createEditVM.UploadedFile != null && createEditVM.UploadedFile.ContentLength > 0)
                    {
                        string path = Path.Combine(Server.MapPath("~/images"),
                             Path.GetFileName(createEditVM.ImageTitle + ".jpg"));

                        createEditVM.UploadedFile.SaveAs(path);
                    }
                }
                //repopulate imagelist and layout models
                return View("Create", createEditVM);
            }
            else //It was just intended to be a save so save everything but don't flag for review
            {
                return View("Create", createEditVM);
            }
           
        }

        public ActionResult Review()
        {
            return View();
        }

    }
}