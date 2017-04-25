using Model.Base;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Repository.Product
{
    public interface IProductRepository: IBaseRepository<Products>
    {
        IQueryable<Products> GetProductsDiscount();
        IQueryable<Products> GetProductLastest();
    }
}
