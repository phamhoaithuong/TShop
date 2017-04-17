using Model.Model;
using Repository.Category;
using Repository.Menu;
using Repository.MenuGroup;
using Repository.Order;
using Repository.OrderDetails;
using Repository.Product;
using Repository.Slide;
using Repository.Vender;
using System;

namespace Model.Base
{
    public interface IUnitOfWork:IDisposable
    {
        TShopDbContext DbContext { get; }
        ICategoryRepository CategoryRepository { get; }
        IMenuGroupRepository MenuGroupRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailsRepository OrderDetailsRepository { get; }
        IProductRepository ProductRepository { get; }
        ISlidetRepository SlidetRepository { get; }
        IVenderRepository VenderRepository { get; }
        IMenuRepositorycs MenuRepositorycs { get; }

        void Commit();
    }
}
