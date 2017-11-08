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
            repo.SetPostLists(createEditVM.Post);
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

                return View("Create", createEditVM);
            }
            else 
            {
                createEditVM.Post = repo.GetPostByID(createEditVM.Post.PostId);
                repo.SetPostLists(createEditVM.Post);
                createEditVM.StaticPosts = repo.GetAllStaticPublished();
                createEditVM.Categories = repo.GetAllCategories();
                createEditVM.Post.PostText = WebUtility.HtmlDecode(createEditVM.Post.PostText);
                createEditVM.Images = repo.GetAllImages();
                return View("Edit", createEditVM.Post.PostId);
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
            repo.SetPostLists(createEditVM.Post);

            return View(createEditVM);
        }

        [HttpPost]
        public ActionResult Review(CreateEditVM createEditVM)
        {
            var repo = RepositoryFactory.GetRepository();  //chose to edit

            if (createEditVM.Post.IsForReview && !createEditVM.Post.IsPublished)
            {
                return RedirectToAction("Edit/" + createEditVM.Post.PostId.ToString());
            }
            else if (createEditVM.Post.IsForReview == false && createEditVM.Post.IsPublished == false)  //returned to contributor
            {
                repo.SavePost(createEditVM.Post);
                return RedirectToAction("Dashboard");  
            }
            else  //published
            {
                repo.SavePost(createEditVM.Post);
                return RedirectToAction("Dashboard");
            }
        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            var repo = RepositoryFactory.GetRepository();
            DashboardVM dashboardVM = new DashboardVM();
            dashboardVM.StaticPosts = repo.GetAllStaticPublished();
            dashboardVM.Categories = repo.GetAllCategories();
            dashboardVM.PostsUnderReview = repo.GetPostForReview();
            dashboardVM.PostsPendingComments = repo.GetAllPosts();
            
            return View(dashboardVM);
        }

    }
}