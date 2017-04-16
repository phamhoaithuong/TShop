using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Model.Model
{
    public class TShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public TShopDbContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Vender> Vender { get; set; }

        public DbSet<Menu> Menu { get; set; }

        public DbSet<MenuGroup> MenuGroup { get; set; }

        public DbSet<Slide> Slide { get; set; }

        public static TShopDbContext Create()
        {
            return new TShopDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
