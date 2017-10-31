using SeaMonsterBlog.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeaMonsterBlog.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Create()
        {
            CreateEditVM createEditVM = new CreateEditVM();
            return View(createEditVM);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreateEditVM createEditVM)
        {
            return View("Create");
        }

        public ActionResult Review()
        {
            return View();
        }
    }
}