using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Model;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(int? take)
        {
            if (take != null)
            {
            }
            //IEnumerable<Products> product = Enumerable.Empty<Products>();
            //using (var uow = new UnitOfWork())
            //{
            //    product = uow.ProductRepository.All();
            //}
                return View();
        }
    }
}