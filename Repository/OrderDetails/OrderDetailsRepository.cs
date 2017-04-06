using Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Model;

namespace Repository.OrderDetails
{
    public class OrderDetailsRepository : BaseRepository, IOrderDetailsRepository
    {
        public OrderDetailsRepository(TShopDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(Model.OrderDetails entity)
        {
            dbContext.OrderDetails.Add(entity);
        }

        public IQueryable<Model.OrderDetails> All(int skipRow = 0, int takeRow = 10)
        {
            return dbContext.OrderDetails.Select(p => p).Skip(skipRow).Take(takeRow);
        }

        public void Delete(Model.OrderDetails entity)
        {
            dbContext.OrderDetails.Remove(entity);
        }

        public void Delete(IEnumerable<Model.OrderDetails> entity)
        {
            foreach (var item in entity)
            {
                dbContext.OrderDetails.Remove(item);
            }
        }

        public Model.OrderDetails GetById(int id)
        {
            return dbContext.OrderDetails.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Model.OrderDetails entity)
        {
            var product = dbContext.OrderDetails.FirstOrDefault(p => p.Id == entity.Id);
            if (product != null)
                product = entity;
        }
    }
}
