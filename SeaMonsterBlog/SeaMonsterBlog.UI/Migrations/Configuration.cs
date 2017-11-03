namespace SeaMonsterBlog.UI.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SeaMonsterBlog.UI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SeaMonsterBlog.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SeaMonsterBlog.UI.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin" };

                manager.Create(user, "testing123");
                manager.AddToRole(user.Id, "admin");
            }

            if (!context.Roles.Any(r => r.Name == "moderator"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "moderator" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "moderator"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "moderator" };

                manager.Create(user, "testing123");
                manager.AddToRole(user.Id, "moderator");
            }

            if (!context.Roles.Any(r => r.Name == "contributer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "contributer" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "contributer"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "contributer" };

                manager.Create(user, "testing123");
                manager.AddToRole(user.Id, "contributer");
            }

            //// Load the user and role managers with our custom models
            //var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            //var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            //// have we loaded roles already?
            //if (!roleMgr.RoleExists("moderator"))
            //{
            //    roleMgr.Create(new AppRole() { Name = "moderator" });
            //    var user = new AppUser()
            //    {
            //        UserName = "moderator"
            //    };
            //    userMgr.Create(user, "testing123");
            //    userMgr.AddToRole(user.Id, "moderator");

            //}

            //if (!roleMgr.RoleExists("contributer"))
            //{
            //    roleMgr.Create(new AppRole() { Name = "contributer" });
            //    var user = new AppUser()
            //    {
            //        UserName = "contributer"
            //    };
            //    userMgr.Create(user, "testing123");
            //    userMgr.AddToRole(user.Id, "contributer");
            //}

            //if (!roleMgr.RoleExists("admin"))
            //{
            //    roleMgr.Create(new AppRole() { Name = "admin" });
            //    var user = new AppUser()
            //    {
            //        UserName = "admin"
            //    };
            //    userMgr.Create(user, "testing123");
            //    userMgr.AddToRole(user.Id, "admin");
            //}
        }
    }
}
