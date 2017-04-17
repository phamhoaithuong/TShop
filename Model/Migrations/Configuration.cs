namespace Model.Migrations
{
    using global::Model.Model;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
           // AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TShopDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            // Create Admin Role
            string roleName = "Admin";
            string roleName1 = "Customer";

            IdentityResult roleResult;
            // Check to see if Role Exists, if not create it
            if (!RoleManager.RoleExists(roleName))
            {
                roleResult = RoleManager.Create(new IdentityRole(roleName));
            }
            if (!RoleManager.RoleExists(roleName1))
            {
                roleResult = RoleManager.Create(new IdentityRole(roleName1));
            }
            // create user admin
            if (UserManager.FindByName("admin@admin.com") == null)
            {
                var user = new ApplicationUser() { UserName = "admin@admin.com" };
                UserManager.Create(user, "Admin@123");
                UserManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
