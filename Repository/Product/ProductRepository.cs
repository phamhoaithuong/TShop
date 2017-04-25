using Model.Base;
using Model.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Repository.Product
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(TShopDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(Products entity)
        {
            dbContext.Products.Add(entity);
        }

        public IQueryable<Products> All(int skipRow = 0, int takeRow = 10)
        {
            return dbContext.Products.Select(p => p).Where(p=>p.Status==true).Skip(skipRow).Take(takeRow).OrderByDescending(p=>p.Id);
        }

        public void Delete(Products entity)
        {
            dbContext.Products.Remove(entity);
        }

        public void Delete(IEnumerable<Products> entity)
        {
            foreach (var item in entity)
            {
                dbContext.Products.Remove(item);
            }
        }

        public Products GetById(int? id)
        {
            return dbContext.Products.FirstOrDefault(p => p.Id == id && p.Status==true);
        }

        public IQueryable<Products> GetProductLastest()
        {
            var products = dbContext.Products.Select(p => p).Where(p => p.Status == true).OrderBy(p=>p.Id).Take(10).OrderByDescending(p => p.Id);

            return products;
        }

        public IQueryable<Products> GetProductsDiscount()
        {
            return dbContext.Products.Select(p => p).Where(p=>p.Discount!=null && p.Status==true).OrderBy(p => p.Id).Take(10).OrderByDescending(p => p.Id);
        }

        public void Update(Products entity)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Id == entity.Id);
            if (product != null)
                product = entity;
        }
    }
}
