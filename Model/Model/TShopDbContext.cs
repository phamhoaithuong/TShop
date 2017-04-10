using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class TShopDbContext : DbContext
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
