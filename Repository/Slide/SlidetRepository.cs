using Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;

namespace Repository.Slide
{
    public class SlidetRepository : BaseRepository, ISlidetRepository
    {
        public SlidetRepository(TShopDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(Model.Model.Slide entity)
        {
            dbContext.Slide.Add(entity);
        }

        public IQueryable<Model.Model.Slide> All(int skipRow = 0, int takeRow = 10)
        {
            return dbContext.Slide.Select(p => p).Skip(skipRow).Take(takeRow);
        }

        public void Delete(Model.Model.Slide entity)
        {
            dbContext.Slide.Remove(entity);
        }

        public void Delete(IEnumerable<Model.Model.Slide> entity)
        {
            foreach (var item in entity)
            {
                dbContext.Slide.Remove(item);
            }
        }

        public Model.Model.Slide GetById(int id)
        {
            return dbContext.Slide.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Model.Model.Slide entity)
        {
            var slide = dbContext.Slide.FirstOrDefault(p => p.Id == entity.Id);
            if (slide != null)
                slide = entity;
        }
    }
}
