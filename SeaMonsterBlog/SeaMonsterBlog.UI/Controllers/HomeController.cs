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
            homeVM.Posts = repo.GetPublishedPosts(); 
            foreach (var p in homeVM.Posts)
            {
                p.PostText = WebUtility.HtmlDecode(p.PostText);
                p.PostText = p.PostText.Substring(60);
                p.PostText = p.PostText.Substring(0, p.PostText.Length - 16);
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

            detailVM.Categories = repo.GetAllCategories();
            if(Request.IsAuthenticated && User.IsInRole("admin")|| Request.IsAuthenticated && User.IsInRole("moderator"))
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
            foreach (var c in model.Post.Comments)
            {
                if (!c.IsShown)
                {
                    repo.DeleteComment(c.CommentId);
                }
                foreach (var r in c.Replies)
                {
                    if (!r.IsShown)
                    {
                        repo.DeleteReply(r.ReplyID);
                    }
                }
            }

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
            var repo = RepositoryFactory.GetRepository();
            if (Request.IsAuthenticated && User.IsInRole("admin"))
            {
                categoryVM.Posts = repo.GetPostByCategory(id);
            }
            else
            {
                categoryVM.Posts = repo.GetPublishedPostByCategory(id);
            }


            return View(categoryVM);
        }

        public ActionResult ByAuthor(string name)
        {
            ByAuthorCategoryVM authorVM = new ByAuthorCategoryVM();

            var repo = RepositoryFactory.GetRepository();
            authorVM.Posts = repo.GetAllPostByAuthor(name);

            return View(authorVM);
        }


        public ActionResult Next(int PostId)
        {
            var repo = RepositoryFactory.GetRepository();

            return RedirectToAction("Details", repo.FindNextPublishedPost(PostId));
        }

        public ActionResult Previous(int PostId)
        {
            var repo = RepositoryFactory.GetRepository();

            return RedirectToAction("Details", repo.FindPreviousPublishedPost(PostId));
        }

        public ActionResult First()
        {
            var repo = RepositoryFactory.GetRepository();

            return RedirectToAction("Details", repo.FindFirstPublishedPost());
        }

        public ActionResult Last()
        {
            var repo = RepositoryFactory.GetRepository();

            return RedirectToAction("Details", repo.FindLastPublishedPost());

        }
    }
}