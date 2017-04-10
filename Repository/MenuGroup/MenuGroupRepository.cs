using Model;
using Model.Base;
using System.Collections.Generic;
using System.Linq;

namespace Repository.MenuGroup
{
    public class MenuGroupRepository : BaseRepository, IMenuGroupRepository
    {
        public MenuGroupRepository(TShopDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(Model.MenuGroup entity)
        {
            dbContext.MenuGroup.Add(entity);
        }

        public IQueryable<Model.MenuGroup> All(int skipRow = 0, int takeRow = 10)
        {
            return dbContext.MenuGroup.Select(p => p).Skip(skipRow).Take(takeRow);
        }

        public void Delete(Model.MenuGroup entity)
        {
            dbContext.MenuGroup.Remove(entity);
        }

        public void Delete(IEnumerable<Model.MenuGroup> entity)
        {
            foreach (var item in entity)
            {
                dbContext.MenuGroup.Remove(item);
            }
        }

        public Model.MenuGroup GetById(int id)
        {
            return dbContext.MenuGroup.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Model.MenuGroup entity)
        {
            var menuGr = dbContext.MenuGroup.FirstOrDefault(p => p.Id == entity.Id);
            if (menuGr != null)
                menuGr = entity;
        }
    }
}
