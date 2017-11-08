using SeaMonsterBlog.Data;
using SeaMonsterBlog.Models.Tables;
using SeaMonsterBlog.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SeaMonsterBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = RepositoryFactory.GetRepository();
            HomeVM homeVM = new HomeVM();
            homeVM.Categories = repo.GetAllCategories();
            homeVM.StaticPosts = repo.GetAllStaticPublished();
            homeVM.Posts = repo.GetPublishedPosts();
            
            foreach (var p in homeVM.Posts)
            {
                p.PostText = WebUtility.HtmlDecode(p.PostText);
                p.PostText = p.PostText.Substring(60);
                p.PostText = p.PostText.Substring(0, p.PostText.Length - 16);
                repo.SetPostLists(p);
            }

            return View(homeVM);
        }

        public ActionResult Detail(int id)
        {
            var repo = RepositoryFactory.GetRepository();
            DetailVM detailVM = new DetailVM();

            detailVM.Post = repo.GetPostByID(id);
            detailVM.Post.PostText = WebUtility.HtmlDecode(detailVM.Post.PostText);
            detailVM.Post.PostText = detailVM.Post.PostText.Substring(60);
            detailVM.Post.PostText = detailVM.Post.PostText.Substring(0, detailVM.Post.PostText.Length - 16);
            repo.SetPostLists(detailVM.Post);
            detailVM.Categories = repo.GetAllCategories();
            detailVM.StaticPosts = repo.GetAllStaticPublished();
            if (Request.IsAuthenticated && User.IsInRole("admin")|| Request.IsAuthenticated && User.IsInRole("moderator"))
            {
                repo.ADMINSetPostList(detailVM.Post);
            }
            else
            {
                repo.SetPostLists(detailVM.Post);
            }

            return View(detailVM);
        }

        [HttpPost]
        public ActionResult Detail (DetailVM model)
        {
            var repo = RepositoryFactory.GetRepository();

            if (model.NewComment != null)
            {
                model.NewComment.PostId = model.Post.PostId;
                repo.CreateComment(model.NewComment);
            }
            if (model.NewReply != null)
                repo.CreateReply(model.NewReply);

            return View("Detail", model);
        }

        public ActionResult ByCategory(int id)
        {
            ByAuthorCategoryVM categoryVM = new ByAuthorCategoryVM();

            // all posts in category where id = categoryId

            // are there categories assigned to published posts? 
            // when running through debugger, int ID is passed in but GetPublishedPostBtyCategory returns list of 0

            var repo = RepositoryFactory.GetRepository();
            if (Request.IsAuthenticated && User.IsInRole("admin"))
            {
                categoryVM.Posts = repo.GetPostByCategory(id);
            }
            else
            {
                categoryVM.Posts = repo.GetPublishedPostByCategory(id);
            }

            categoryVM.StaticPosts = repo.GetAllStaticPublished();
            categoryVM.Categories = repo.GetAllCategories();
            categoryVM.Category = categoryVM.Categories.FirstOrDefault(c => c.CategoryID == id);
            categoryVM.CategoriesSelectList = (from category in categoryVM.Categories
                                               select new SelectListItem()
                                               {
                                                   Text = category.CategoryTag,
                                                   Value = category.CategoryID.ToString(),
                                               }).ToList();

            foreach(var post in categoryVM.Posts)
            {
                repo.SetPostLists(post);
            }

            return View(categoryVM);
        }

        [HttpPost]
        public ActionResult ByCategory(ByAuthorCategoryVM authorCategoryVM)
        {
            ByAuthorCategoryVM categoryVM = new ByAuthorCategoryVM();

            var repo = RepositoryFactory.GetRepository();
            if (Request.IsAuthenticated && User.IsInRole("admin"))
            {
                categoryVM.Posts = repo.GetPostByCategory(authorCategoryVM.CategoryId);
            }
            else
            {
                categoryVM.Posts = repo.GetPublishedPostByCategory(authorCategoryVM.CategoryId);
            }

            categoryVM.StaticPosts = repo.GetAllStaticPublished();
            categoryVM.Categories = repo.GetAllCategories();
            categoryVM.Category = categoryVM.Categories.FirstOrDefault(c => c.CategoryID == authorCategoryVM.CategoryId);
            categoryVM.CategoriesSelectList = (from category in categoryVM.Categories
                                               select new SelectListItem()
                                               {
                                                   Text = category.CategoryTag,
                                                   Value = category.CategoryID.ToString(),
                                               }).ToList();

            return View(categoryVM);
        }

        public ActionResult ByAuthor(string id)
        {
            ByAuthorCategoryVM authorVM = new ByAuthorCategoryVM();

            var repo = RepositoryFactory.GetRepository();
            authorVM.Categories = repo.GetAllCategories();
            authorVM.StaticPosts = repo.GetAllStaticPublished();

            if (id == "1")
            {
                authorVM.AuthorName = "All Authors";

                if (Request.IsAuthenticated && User.IsInRole("admin"))
                {
                    authorVM.Posts = repo.GetAllPosts();
                }
                else
                {
                    authorVM.Posts = repo.GetPublishedPosts();
                }
            }
            else
            {
                authorVM.AuthorName = id;

                if (Request.IsAuthenticated && User.IsInRole("admin"))
                {
                    authorVM.Posts = repo.GetAllPostByAuthor(id);
                }
                else
                {
                    authorVM.Posts = repo.GetPublishedPostbyAuthor(id);
                }
            }
            
            
            authorVM.AuthorsSelectList = (from author in repo.GetAllAuthors()
                                          select new SelectListItem()
                                          {
                                              Text = author,
                                              Value = author,
                                          }).ToList();
                
            
            return View(authorVM);
        }

        [HttpPost]
        public ActionResult ByAuthor(ByAuthorCategoryVM authorCategoryVM)
        {
            ByAuthorCategoryVM authorVM = new ByAuthorCategoryVM();
            authorVM.AuthorName = authorCategoryVM.AuthorName;

            var repo = RepositoryFactory.GetRepository();
            if (Request.IsAuthenticated && User.IsInRole("admin"))
            {
                authorVM.Posts = repo.GetAllPostByAuthor(authorCategoryVM.AuthorName);
            }
            else
            {
                authorVM.Posts = repo.GetPublishedPostbyAuthor(authorCategoryVM.AuthorName);
            }

            authorVM.StaticPosts = repo.GetAllStaticPublished();
            authorVM.Categories = repo.GetAllCategories();
            authorVM.AuthorsSelectList = (from author in repo.GetAllAuthors()
                                          select new SelectListItem()
                                          {
                                              Text = author,
                                              Value = author,
                                          }).ToList();


            return View(authorVM);
        }

        public ActionResult ByHashtag(int id)
        {
            var repo = RepositoryFactory.GetRepository();
            ByHashtagVM hashtagVM = new ByHashtagVM();
            hashtagVM.Categories = repo.GetAllCategories();
            hashtagVM.StaticPosts = repo.GetAllStaticPublished();
            hashtagVM.Posts = repo.GetPublishedPostbyHashtag(id);
            hashtagVM.Hashtag = repo.GetHashtags().FirstOrDefault(h => h.HashtagID == id);

            foreach (var p in hashtagVM.Posts)
            {
                p.PostText = WebUtility.HtmlDecode(p.PostText);
                p.PostText = p.PostText.Substring(60);
                p.PostText = p.PostText.Substring(0, p.PostText.Length - 16);
                repo.SetPostLists(p);
            }

            return View(hashtagVM);
        }


        public ActionResult Next(int id)
        {
            var repo = RepositoryFactory.GetRepository();

            return RedirectToAction("Detail/" + repo.FindNextPublishedPost(id).ToString());
        }

        public ActionResult Previous(int id)
        {
            var repo = RepositoryFactory.GetRepository();

            return RedirectToAction("Detail/" + repo.FindPreviousPublishedPost(id).ToString());
        }

        public ActionResult First()
        {
            var repo = RepositoryFactory.GetRepository();

            return RedirectToAction("Details/" + repo.FindFirstPublishedPost().ToString());
        }

        public ActionResult Last()
        {
            var repo = RepositoryFactory.GetRepository();

            return RedirectToAction("Details/" + repo.FindLastPublishedPost().ToString());

        }
    }
}