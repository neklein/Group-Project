using SeaMonsterBlog.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeaMonsterBlog.Data;
using System.Net;
using SeaMonsterBlog.Models.Tables;

namespace SeaMonsterBlog.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize(Roles = "admin, moderator")]
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

        [HttpGet]
        [Authorize(Roles = "admin, moderator")]
        public ActionResult Edit(int id)
        {
            var repo = RepositoryFactory.GetRepository();
            CreateEditVM createEditVM = new CreateEditVM();
            createEditVM.Post = repo.GetPostByID(id);
            repo.SetPostLists(createEditVM.Post);
            createEditVM.Post.PostText = WebUtility.HtmlDecode(createEditVM.Post.PostText);
            createEditVM.Post.PostText = createEditVM.Post.PostText.Substring(52);
            createEditVM.Post.PostText = createEditVM.Post.PostText.Substring(0, createEditVM.Post.PostText.Length - 16);
            createEditVM.Categories = repo.GetAllCategories();
            createEditVM.StaticPosts = repo.GetAllStaticPublished();
            createEditVM.Images = repo.GetAllImages();
            createEditVM.Post.IsPublished = false;
            return View(createEditVM);
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "admin, moderator")]
        public ActionResult Edit(CreateEditVM createEditVM)
        {
            if (string.IsNullOrEmpty(createEditVM.Post.PostTitle) || string.IsNullOrEmpty(createEditVM.Post.PostText) || string.IsNullOrEmpty(createEditVM.Post.Author))
            {
                ModelState.AddModelError("NotValid", "A title, author and text are required before saving/submitting");
            }

            if (ModelState.IsValid)
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
                    return RedirectToAction("Review/" + createEditVM.Post.PostId);
                }
                if (createEditVM.UploadedFile != null)
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
                    repo.SetPostLists(createEditVM.Post);
                    createEditVM.StaticPosts = repo.GetAllStaticPublished();
                    createEditVM.Categories = repo.GetAllCategories();
                    createEditVM.Post.PostText = WebUtility.HtmlDecode(createEditVM.Post.PostText);
                    createEditVM.Images = repo.GetAllImages();
                    return View("Edit", createEditVM);
                }
                else
                {
                    createEditVM.Post = repo.GetPostByID(createEditVM.Post.PostId);
                    repo.SetPostLists(createEditVM.Post);
                    createEditVM.StaticPosts = repo.GetAllStaticPublished();
                    createEditVM.Categories = repo.GetAllCategories();
                    createEditVM.Post.PostText = WebUtility.HtmlDecode(createEditVM.Post.PostText);
                    createEditVM.Images = repo.GetAllImages();
                    return View("Edit", createEditVM);
                }
            }
            else
            {
                var repo = RepositoryFactory.GetRepository();

                repo.SetPostLists(createEditVM.Post);
                createEditVM.StaticPosts = repo.GetAllStaticPublished();
                createEditVM.Categories = repo.GetAllCategories();
                createEditVM.Post.PostText = WebUtility.HtmlDecode(createEditVM.Post.PostText);
                createEditVM.Images = repo.GetAllImages();
                return View(createEditVM);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "admin, moderator")]
        public ActionResult Create(CreateEditVM createEditVM)
        {
            if (string.IsNullOrEmpty(createEditVM.Post.PostTitle)|| string.IsNullOrEmpty(createEditVM.Post.PostText)|| string.IsNullOrEmpty(createEditVM.Post.Author))
            {
                ModelState.AddModelError("NotValid", "A title, author and text are required before saving/submitting");
            }

            if (ModelState.IsValid)
            {
                createEditVM.Post.PostText = WebUtility.HtmlEncode(createEditVM.Post.PostText);
                if (createEditVM.ChosenCategories != null)
                {
                    createEditVM.Post.SelectedCategories = ConvertChosenToSelected(createEditVM.ChosenCategories);
                }
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
                    repo.SetPostLists(createEditVM.Post);
                    createEditVM.StaticPosts = repo.GetAllStaticPublished();
                    createEditVM.Categories = repo.GetAllCategories();
                    createEditVM.Post.PostText = WebUtility.HtmlDecode(createEditVM.Post.PostText);
                    createEditVM.Images = repo.GetAllImages();
                    return View(createEditVM);
                }
                else
                {
                    createEditVM.Post = repo.GetPostByID(createEditVM.Post.PostId);
                    repo.SetPostLists(createEditVM.Post);
                    createEditVM.StaticPosts = repo.GetAllStaticPublished();
                    createEditVM.Categories = repo.GetAllCategories();
                    createEditVM.Post.PostText = WebUtility.HtmlDecode(createEditVM.Post.PostText);
                    createEditVM.Images = repo.GetAllImages();
                    return View(createEditVM);
                }
            }
            else
            {
                var repo = RepositoryFactory.GetRepository();

                repo.SetPostLists(createEditVM.Post);
                createEditVM.StaticPosts = repo.GetAllStaticPublished();
                createEditVM.Categories = repo.GetAllCategories();
                createEditVM.Post.PostText = WebUtility.HtmlDecode(createEditVM.Post.PostText);
                createEditVM.Images = repo.GetAllImages();
                return View(createEditVM);
            }
           
        }

        [HttpGet]
        [Authorize(Roles = "admin, moderator")]
        public ActionResult Review(int id)
        {
            var repo = RepositoryFactory.GetRepository();

            CreateEditVM createEditVM = new CreateEditVM();

            createEditVM.Post = repo.GetPostByID(id);
            createEditVM.Post.PostText = WebUtility.HtmlDecode(createEditVM.Post.PostText);
            createEditVM.Post.PostText = createEditVM.Post.PostText.Substring(52);
            createEditVM.Post.PostText = createEditVM.Post.PostText.Substring(0, createEditVM.Post.PostText.Length - 16);
            createEditVM.Categories = repo.GetAllCategories();
            createEditVM.StaticPosts = repo.GetAllStaticPublished();
            repo.SetPostLists(createEditVM.Post);


            return View(createEditVM);
        }

        [HttpPost]
        [Authorize(Roles = "admin, moderator")]
        public ActionResult Review(CreateEditVM createEditVM)
        {

            var repo = RepositoryFactory.GetRepository();  //chose to edit

            if ((createEditVM.Post.IsForReview && !createEditVM.Post.IsPublished)&& !Request.IsAuthenticated && User.IsInRole("moderator"))
            {
                return RedirectToAction("Edit/" + createEditVM.Post.PostId.ToString());
            }
            else if (Request.IsAuthenticated && User.IsInRole("moderator"))
            {
                repo.Review(createEditVM.Post);
                return RedirectToAction("Dashboard");
            }

            else if (createEditVM.Post.IsForReview == false && createEditVM.Post.IsPublished == false)  //returned to contributor
            {
                repo.Review(createEditVM.Post);
                return RedirectToAction("Dashboard");  
            }
            else  //published
            {
                repo.Review(createEditVM.Post);
                return RedirectToAction("Dashboard");
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin, moderator")]
        public ActionResult Dashboard()
        {
            var repo = RepositoryFactory.GetRepository();
            DashboardVM dashboardVM = new DashboardVM();
            dashboardVM.StaticPosts = repo.GetAllStaticPublished();
            dashboardVM.Categories = repo.GetAllCategories();
            if (Request.IsAuthenticated && User.IsInRole("admin"))
            {
                dashboardVM.PostsUnderReview = repo.GetPostForReview();
            }
            if (Request.IsAuthenticated && User.IsInRole("moderator"))
            {
                var posts = repo.GetAllPosts();
                dashboardVM.PostsUnderReview = (from p in posts
                                                where p.IsPublished == false && p.IsForReview == false
                                                select p).ToList();
            }

            dashboardVM.PostsPendingComments = repo.GetPostsWithUnapprovedCommentsAndReplies();
            dashboardVM.CategoryPickList = new SelectList(dashboardVM.Categories, "CategoryID", "CategoryTag");


            return View(dashboardVM);
        }

        [HttpPost]
        [Authorize(Roles = "admin, moderator")]
        public ActionResult Dashboard(DashboardVM model)
        {
            var repo = RepositoryFactory.GetRepository();

            if (model.DeleteCategory != null)
            {
                repo.DeleteCategory((int)model.DeleteCategory);
            }

            if (model.NewCategory != null)
            {
                repo.CreateCategory(model.NewCategory);
            }
            return RedirectToAction("Dashboard");
        }


        private List<Category> ConvertChosenToSelected(List<int> ids)
        {
            var repo = RepositoryFactory.GetRepository();
            var catagories = repo.GetAllCategories();
            var selectedCategories = (from i in ids
                                      join c in catagories on i equals c.CategoryID
                                      select c);
            return (selectedCategories.ToList());
        }

    }
}