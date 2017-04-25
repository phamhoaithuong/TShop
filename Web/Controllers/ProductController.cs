using Model.Base;
using Model.Model;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home", null);
            Products product = new Products();
            ProductViewModel result = new ProductViewModel();
            using (var uow = new UnitOfWork())
            {
                product = uow.ProductRepository.GetById(id);
                if (product != null)
                {
                    result.Product = product;
                    result.ArrayImage = product.Image.Split(';');
                }
                else throw new HttpException("404");
            }
            return View(result);
        }
    }
}