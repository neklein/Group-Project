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
            // Load the user and role managers with our custom models
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            // have we loaded roles already?
            if (!roleMgr.RoleExists("moderator"))
            {
                roleMgr.Create(new AppRole() { Name = "moderator" });
                var user = new AppUser()
                {
                    UserName = "moderator"
                };
                userMgr.Create(user, "testing123");
                userMgr.AddToRole(user.Id, "moderator");

            }

            if (!roleMgr.RoleExists("contributer"))
            {
                roleMgr.Create(new AppRole() { Name = "contributer" });
                var user = new AppUser()
                {
                    UserName = "contributer"
                };
                userMgr.Create(user, "testing123");
                userMgr.AddToRole(user.Id, "contributer");
            }

            if (!roleMgr.RoleExists("admin"))
            {
                roleMgr.Create(new AppRole() { Name = "admin" });
                var user = new AppUser()
                {
                    UserName = "admin"
                };
                userMgr.Create(user, "testing123");
                userMgr.AddToRole(user.Id, "admin");
            }
        }
    }
}
