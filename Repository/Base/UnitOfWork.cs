using Model.Base;
using Model.Model;
using Repository.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private TShopDbContext dbContext;
        private ICategoryRepository _categoryRepository;
        public UnitOfWork()
        {
            dbContext = new TShopDbContext();
        }

        public TShopDbContext DbContext
        {
            get { return dbContext ?? (dbContext = new TShopDbContext()); }
        }

        public ICategoryRepository CategoryRepository
        {
            get { return _categoryRepository ?? (_categoryRepository= new CategoryRepository(DbContext)); }
        }

        public void Commit()
        {
            try
            {
                DbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                ResetRepositories();
            }
        }

        public void Dispose()
        {
            //Disposing(true);
            GC.SuppressFinalize(this);
        }

        private void Disposing(bool v)
        {
            throw new NotImplementedException();
        }

        private void ResetRepositories()
        {
            _categoryRepository = null;
        }
    }
}
