using SeaMonsterBlog.Data;
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
            homeVM.Posts = repo.GetAllPosts(); 
            foreach (var p in homeVM.Posts)
            {
                p.PostText = WebUtility.HtmlDecode(p.PostText);
                p.PostText = p.PostText.Substring(53);
                p.PostText = p.PostText.Substring(0, p.PostText.Length - 16);
            }

            return View(homeVM);
        }

        public ActionResult Detail(int id)
        {
            var repo = RepositoryFactory.GetRepository();
            DetailVM detailVM = new DetailVM();

            detailVM.Categories = repo.GetAllCategories();
            detailVM.Post = repo.GetPostByID(id);
            detailVM.Post.Comments = repo.GetAllComments(id);
            //detailVM.Post.Comments.Replies = repo.GetAllReply();

            return View(detailVM);
        }

        public ActionResult ByCategory(int id)
        {
            ByAuthorCategoryVM categoryVM = new ByAuthorCategoryVM();

            // all posts in category where id = categoryId

            return View(categoryVM);
        }

        public ActionResult ByAuthor(int id)
        {
            ByAuthorCategoryVM authorVM = new ByAuthorCategoryVM();

            // all posts by author where id = authorId

            return View(authorVM);
        }
    }
}