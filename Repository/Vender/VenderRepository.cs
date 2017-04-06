using Model.Base;
using Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Vender
{
    public class VenderRepository : BaseRepository, IVenderRepository
    {
        public VenderRepository(TShopDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(Model.Vender entity)
        {
            dbContext.Vender.Add(entity);
        }

        public IQueryable<Model.Vender> All(int skipRow = 0, int takeRow = 10)
        {
            return dbContext.Vender.Select(p => p).Skip(skipRow).Take(takeRow);
        }

        public void Delete(Model.Vender entity)
        {
            dbContext.Vender.Remove(entity);
        }

        public void Delete(IEnumerable<Model.Vender> entity)
        {
            foreach (var item in entity)
            {
                dbContext.Vender.Remove(item);
            }
        }

        public Model.Vender GetById(int id)
        {
            return dbContext.Vender.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Model.Vender entity)
        {
            var vender = dbContext.Vender.FirstOrDefault(p => p.Id == entity.Id);
            if (vender != null)
                vender = entity;
        }
    }
}
