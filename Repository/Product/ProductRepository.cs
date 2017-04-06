using Model.Base;
using Repository.Vender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Model;

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
            return dbContext.Products.Select(p => p).Skip(skipRow).Take(takeRow);
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

        public Products GetById(int id)
        {
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Products entity)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Id == entity.Id);
            if (product != null)
                product = entity;
        }
    }
}
