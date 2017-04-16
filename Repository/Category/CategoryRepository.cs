using Model.Base;
using Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Category
{
    public class CategoryRepository :BaseRepository, ICategoryRepository
    {
        public CategoryRepository(TShopDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(Categories entity)
        {
            dbContext.Categories.Add(entity);
        }

        public IQueryable<Categories> All(int skipRow = 0, int takeRow = 10)
        {
            return dbContext.Categories.Select(p => p).Skip(skipRow).Take(takeRow);
        }

        public void Delete(Categories entity)
        {
            dbContext.Categories.Remove(entity);
        }

        public void Delete(IEnumerable<Categories> entity)
        {
            foreach (var item in entity)
            {
                dbContext.Categories.Remove(item);
            }
        }

        public Categories GetById(int id)
        {
            return dbContext.Categories.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Categories entity)
        {
            var cate = dbContext.Categories.FirstOrDefault(p => p.Id == entity.Id);
            if (cate != null)
                cate = entity;
        }
    }
}
