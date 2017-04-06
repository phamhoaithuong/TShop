using Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Model;

namespace Repository.Order
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(TShopDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(Model.Order entity)
        {
            dbContext.Order.Add(entity);
        }

        public IQueryable<Model.Order> All(int skipRow = 0, int takeRow = 10)
        {
            return dbContext.Order.Select(p => p).Skip(skipRow).Take(takeRow);
        }

        public void Delete(Model.Order entity)
        {
            dbContext.Order.Remove(entity);
        }

        public void Delete(IEnumerable<Model.Order> entity)
        {
            foreach (var item in entity)
            {
                dbContext.Order.Remove(item);
            }
        }

        public Model.Order GetById(int id)
        {
            return dbContext.Order.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Model.Order entity)
        {
            var orther = dbContext.Order.FirstOrDefault(p => p.Id == entity.Id);
            if (orther != null)
                orther = entity;
        }
    }
}
