using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Model;
using System.Collections;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _Lastest()
        {
            IEnumerable<Products> product = Enumerable.Empty<Products>();
            List<ProductViewModel> result = new List<ProductViewModel>(); 
            using (var uow = new UnitOfWork())
            {
                product = uow.ProductRepository.GetProductLastest();
                foreach (var i in product)
                {
                    ProductViewModel pro = new ProductViewModel();
                    pro.Product = i;
                    pro.ArrayImage = i.Image.Split(';');
                    result.Add(pro);
                }
            }            
                return PartialView(result);
        }

        public PartialViewResult _OnSale()
        {
            IEnumerable<Products> product = Enumerable.Empty<Products>();
            List<ProductViewModel> result = new List<ProductViewModel>(); 
            using (var uow = new UnitOfWork())
            {
                product = uow.ProductRepository.GetProductsDiscount();
                foreach (var i in product)
                {
                    ProductViewModel pro = new ProductViewModel();
                    pro.Product = i;
                    pro.ArrayImage = i.Image.Split(';');
                    result.Add(pro);
                }
            }
            return PartialView(result);
        }

        public PartialViewResult _Header()
        {
            IEnumerable<Categories> result = Enumerable.Empty<Categories>();
            using (var uow = new UnitOfWork())
            {
                result = uow.CategoryRepository.All();
            }
            return PartialView(result);
        }

        public PartialViewResult _Brand()
        {
            IEnumerable<Vender> result = Enumerable.Empty<Vender>();
            using (var uow = new UnitOfWork())
            {
                result = uow.VenderRepository.All();
            }
            return PartialView(result);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}