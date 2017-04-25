using Model;
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
        public void Add(Model.Model.Vender entity)
        {
            dbContext.Vender.Add(entity);
        }

        public IQueryable<Model.Model.Vender> All(int skipRow = 0, int takeRow = 10)
        {
            return dbContext.Vender.Select(p => p).OrderBy(p=>p.Id).Skip(skipRow).Take(takeRow);
        }

        public void Delete(Model.Model.Vender entity)
        {
            dbContext.Vender.Remove(entity);
        }

        public void Delete(IEnumerable<Model.Model.Vender> entity)
        {
            foreach (var item in entity)
            {
                dbContext.Vender.Remove(item);
            }
        }

        public Model.Model.Vender GetById(int? id)
        {
            return dbContext.Vender.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Model.Model.Vender entity)
        {
            var vender = dbContext.Vender.FirstOrDefault(p => p.Id == entity.Id);
            if (vender != null)
                vender = entity;
        }
    }
}
