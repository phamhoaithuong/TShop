using Model.Model;
using Repository.Base;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Common;

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

        [ChildActionOnly]
        public PartialViewResult _Header()
        {
            var cart = Session[Constants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
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
    }
}