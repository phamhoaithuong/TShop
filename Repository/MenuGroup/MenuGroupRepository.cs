using Model.Base;
using Model.Model;
using Repository.Vender;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.MenuGroup
{
    public class MenuGroupRepository : BaseRepository, IMenuGrouprRepository
    {
        public MenuGroupRepository(TShopDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(Model.Model.MenuGroup entity)
        {
            dbContext.MenuGroup.Add(entity);
        }

        public IQueryable<Model.Model.MenuGroup> All(int skipRow = 0, int takeRow = 10)
        {
            return dbContext.MenuGroup.Select(p => p).Skip(skipRow).Take(takeRow);
        }

        public void Delete(Model.Model.MenuGroup entity)
        {
            dbContext.MenuGroup.Remove(entity);
        }

        public void Delete(IEnumerable<Model.Model.MenuGroup> entity)
        {
            foreach (var item in entity)
            {
                dbContext.MenuGroup.Remove(item);
            }
        }

        public Model.Model.MenuGroup GetById(int id)
        {
            return dbContext.MenuGroup.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Model.Model.MenuGroup entity)
        {
            var menuGr = dbContext.MenuGroup.FirstOrDefault(p => p.Id == entity.Id);
            if (menuGr != null)
                menuGr = entity;
        }
    }
}
