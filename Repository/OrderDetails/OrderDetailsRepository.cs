using Model.Base;
using Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace Repository.OrderDetails
{
    public class OrderDetailsRepository : BaseRepository, IOrderDetailsRepository
    {
        public OrderDetailsRepository(TShopDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(Model.Model.OrderDetails entity)
        {
            dbContext.OrderDetails.Add(entity);
        }

        public IQueryable<Model.Model.OrderDetails> All(int skipRow = 0, int takeRow = 10)
        {
            return dbContext.OrderDetails.Select(p => p).Skip(skipRow).Take(takeRow);
        }

        public void Delete(Model.Model.OrderDetails entity)
        {
            dbContext.OrderDetails.Remove(entity);
        }

        public void Delete(IEnumerable<Model.Model.OrderDetails> entity)
        {
            foreach (var item in entity)
            {
                dbContext.OrderDetails.Remove(item);
            }
        }

        public Model.Model.OrderDetails GetById(int id)
        {
            return dbContext.OrderDetails.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Model.Model.OrderDetails entity)
        {
            var product = dbContext.OrderDetails.FirstOrDefault(p => p.Id == entity.Id);
            if (product != null)
                product = entity;
        }
    }
}
