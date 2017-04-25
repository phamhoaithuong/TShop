using Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;

namespace Repository.Menu
{
    public class MenuRepository : BaseRepository, IMenuRepositorycs
    {
        public MenuRepository(TShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Model.Model.Menu entity)
        {
            dbContext.Menu.Add(entity);
        }

        public IQueryable<Model.Model.Menu> All(int skipRow = 0, int takeRow = 10)
        {
            return dbContext.Menu.Select(p => p).Skip(skipRow).Take(takeRow);
        }

        public void Delete(Model.Model.Menu entity)
        {
            dbContext.Menu.Remove(entity);
        }

        public void Delete(IEnumerable<Model.Model.Menu> entity)
        {
            foreach (var item in entity)
            {
                dbContext.Menu.Remove(item);
            }
        }

        public Model.Model.Menu GetById(int? id)
        {
            return dbContext.Menu.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Model.Model.Menu entity)
        {
            var menu = dbContext.Menu.FirstOrDefault(p => p.Id == entity.Id);
            if (menu != null)
                menu = entity;
        }
    }
}
