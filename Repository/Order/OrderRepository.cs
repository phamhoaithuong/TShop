using Model;
using Model.Base;
using Model.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Repository.Order
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(TShopDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public int Insert(Model.Model.Order entity)
        {
            dbContext.Order.Add(entity);
            return entity.Id;
        }

        public IQueryable<Model.Model.Order> All(int skipRow = 0, int takeRow = 10)
        {
            return dbContext.Order.Select(p => p).Skip(skipRow).Take(takeRow);
        }

        public void Delete(Model.Model.Order entity)
        {
            dbContext.Order.Remove(entity);
        }

        public void Delete(IEnumerable<Model.Model.Order> entity)
        {
            foreach (var item in entity)
            {
                dbContext.Order.Remove(item);
            }
        }

        public Model.Model.Order GetById(int? id)
        {
            return dbContext.Order.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Model.Model.Order entity)
        {
            var orther = dbContext.Order.FirstOrDefault(p => p.Id == entity.Id);
            if (orther != null)
                orther = entity;
        }

        void IBaseRepository<Model.Model.Order>.Add(Model.Model.Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
