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
            createEditVM.Images = repo.GetAllImages();
            
            return View(createEditVM);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreateEditVM createEditVM)
        {
            var repo = RepositoryFactory.GetRepository();
            if (createEditVM.Post.PostId == 0)    //Save or add work regardless of button choice
            {
                createEditVM.Post.PostId = repo.CreateNewPost(createEditVM.Post);
            }
            else
                repo.SavePost(createEditVM.Post);


            string fileName;
            if (createEditVM.Post.IsForReview)
            {
                return Redirect("Review/" + createEditVM.Post.PostId);
            }
            else if (createEditVM.UploadedFile != null)
            {
                fileName = createEditVM.UploadedFile.FileName;

                if (fileName != null && fileName.Contains(".jpg"))
                {
                    if (createEditVM.ImageTitle == null)
                        fileName = createEditVM.UploadedFile.FileName;
                    else
                       fileName = createEditVM.ImageTitle + ".jpg";

                    if (createEditVM.UploadedFile != null && createEditVM.UploadedFile.ContentLength > 0)
                    {
                        string path = Path.Combine(Server.MapPath("~/images"),
                             Path.GetFileName(fileName));

                        createEditVM.UploadedFile.SaveAs(path);
                        repo.SaveNewImage(fileName);
                    }
                }
                createEditVM.Categories = repo.GetAllCategories();
                createEditVM.Images = repo.GetAllImages();
                return View("Create", createEditVM);
            }
            else 
            {
                createEditVM.Categories = repo.GetAllCategories();
                createEditVM.Images = repo.GetAllImages();
                return View("Create", createEditVM);
            }
           
        }

        public ActionResult Review()
        {
            return View();
        }

    }
}