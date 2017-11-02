using SeaMonsterBlog.Data;
using SeaMonsterBlog.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

            

            return View(homeVM);
        }

        public ActionResult Detail(int id)
        {
            var repo = RepositoryFactory.GetRepository();


            return View();
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