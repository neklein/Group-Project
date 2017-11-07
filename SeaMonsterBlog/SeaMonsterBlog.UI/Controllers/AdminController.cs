using SeaMonsterBlog.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeaMonsterBlog.Data;
using System.Net;

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
            createEditVM.StaticPosts = repo.GetAllStaticPublished();
            createEditVM.Images = repo.GetAllImages();
            createEditVM.Post = new SeaMonsterBlog.Models.Tables.Post();            
            return View(createEditVM);
        }

        public ActionResult Edit(int id)
        {
            var repo = RepositoryFactory.GetRepository();
            CreateEditVM createEditVM = new CreateEditVM();
            createEditVM.Post = repo.GetPostByID(id);
            createEditVM.Post.PostText = WebUtility.HtmlDecode(createEditVM.Post.PostText);
            createEditVM.Post.PostText = createEditVM.Post.PostText.Substring(53);
            createEditVM.Post.PostText = createEditVM.Post.PostText.Substring(0, createEditVM.Post.PostText.Length - 16);
            createEditVM.Categories = repo.GetAllCategories();
            createEditVM.StaticPosts = repo.GetAllStaticPublished();
            createEditVM.Images = repo.GetAllImages();
            return View("Create",createEditVM);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreateEditVM createEditVM)
        {
            createEditVM.Post.PostText = WebUtility.HtmlEncode(createEditVM.Post.PostText);
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
                createEditVM.StaticPosts = repo.GetAllStaticPublished();
                createEditVM.Images = repo.GetAllImages();
                createEditVM.Post.PostText = WebUtility.HtmlDecode(createEditVM.Post.PostText);
                return View("Create", createEditVM);
            }
            else 
            {
                createEditVM.Post = repo.GetPostByID(createEditVM.Post.PostId);
                createEditVM.StaticPosts = repo.GetAllStaticPublished();
                createEditVM.Categories = repo.GetAllCategories();
                createEditVM.Post.PostText = WebUtility.HtmlDecode(createEditVM.Post.PostText);
                createEditVM.Images = repo.GetAllImages();
                return View("Create", createEditVM);
            }
           
        }

        [HttpGet]
        public ActionResult Review(int id)
        {
            var repo = RepositoryFactory.GetRepository();

            CreateEditVM createEditVM = new CreateEditVM();

            createEditVM.Post = repo.GetPostByID(id);
            createEditVM.Post.PostText = WebUtility.HtmlDecode(createEditVM.Post.PostText);
            createEditVM.Post.PostText = createEditVM.Post.PostText.Substring(53);
            createEditVM.Post.PostText = createEditVM.Post.PostText.Substring(0, createEditVM.Post.PostText.Length - 16);
            createEditVM.Categories = repo.GetAllCategories();
            createEditVM.StaticPosts = repo.GetAllStaticPublished();

            return View(createEditVM);
        }

        [HttpPost]
        public ActionResult Review(CreateEditVM createEditVM)
        {
            var repo = RepositoryFactory.GetRepository();  //chose to edit

            if (createEditVM.Post.IsForReview && !createEditVM.Post.IsPublished)
            {
                createEditVM.Categories = repo.GetAllCategories();
                createEditVM.StaticPosts = repo.GetAllStaticPublished();
                createEditVM.Images = repo.GetAllImages();
                return RedirectToAction("Create", createEditVM);
            }
            else if (createEditVM.Post.IsForReview == false && createEditVM.Post.IsPublished == false)  //returned to contributor
            {
                repo.SavePost(createEditVM.Post);
                throw new NotImplementedException();  //return to admin/console??
            }
            else  //published
            {
                repo.SavePost(createEditVM.Post);
                throw new NotImplementedException();  //also admin/console??
            }
        }

    }
}