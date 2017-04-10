using Model;
using Model.Base;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Slide
{
    public class SlidetRepository : BaseRepository, ISlidetRepository
    {
        public SlidetRepository(TShopDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(Model.Slide entity)
        {
            dbContext.Slide.Add(entity);
        }

        public IQueryable<Model.Slide> All(int skipRow = 0, int takeRow = 10)
        {
            return dbContext.Slide.Select(p => p).Skip(skipRow).Take(takeRow);
        }

        public void Delete(Model.Slide entity)
        {
            dbContext.Slide.Remove(entity);
        }

        public void Delete(IEnumerable<Model.Slide> entity)
        {
            foreach (var item in entity)
            {
                dbContext.Slide.Remove(item);
            }
        }

        public Model.Slide GetById(int id)
        {
            return dbContext.Slide.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Model.Slide entity)
        {
            var slide = dbContext.Slide.FirstOrDefault(p => p.Id == entity.Id);
            if (slide != null)
                slide = entity;
        }
    }
}
