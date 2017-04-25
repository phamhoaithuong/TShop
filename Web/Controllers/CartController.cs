using Model.Model;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using Web.Common;
using Web.App_Start;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public CartController()
        {
        }

        public CartController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Cart
        //[Authorize]
        public ActionResult Index()
        {
            var cart = Session[Common.Constants.CartSession];
            var list = new List<CartItem>();
            if(cart!=null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        //[Authorize]
        public ActionResult AddItem(int productId, int quantity)
        {
            Products product = new Products();
            using (var uow = new UnitOfWork())
            {
                product = uow.ProductRepository.GetById(productId);                
            }
            var cart = Session[Common.Constants.CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(p => p.Product.Id == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.Id == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                Session[Common.Constants.CartSession] = list;

            }
            return RedirectToAction("Index");
        }

        public JsonResult Update(string cartModel)
        {
            try
            {
                var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
                var sessionCart = (List<CartItem>)Session[Common.Constants.CartSession];
                foreach (var item in sessionCart)
                {
                    var jsonItem = jsonCart.SingleOrDefault(p => p.Product.Id == item.Product.Id);
                    if (jsonItem != null)
                    {
                        item.Quantity = jsonItem.Quantity;
                    }

                }
                Session[Common.Constants.CartSession] = sessionCart;
                return Json(new { status = true });
            }
            catch (Exception)
            {

                throw new HttpException(404, "Có điều gì đó sai sai");
            }            
        }

        public JsonResult Delete(int id)
        {
            var sesstionCart = (List<CartItem>)Session[Common.Constants.CartSession];
            sesstionCart.RemoveAll(p => p.Product.Id == id);
            Session[Common.Constants.CartSession] = sesstionCart;
            return Json(new { status = true });
        }


        public ActionResult DeleteAll()
        {
            Session[Common.Constants.CartSession] = null;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CheckOut()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            string id = User.Identity.GetUserId();
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            return View(user);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CheckOut(string type)
        {
            if (Session[Common.Constants.CartSession] == null)
                return RedirectToAction("Index", "Home");
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            using (var uow = new UnitOfWork())
            {
                Order order = new Order();
                order.UserID = user.Id;
                order.Email = user.Email;
                order.Address = user.Address;
                order.Phone = user.PhoneNumber;
                order.Status = false;
                order.Created = DateTime.Now;
                int id = uow.OrderRepository.Insert(order);
                var cart = (List<CartItem>)Session[Common.Constants.CartSession];
                foreach (var i in cart)
                {
                    var detail = new OrderDetails();
                    detail.Product_Id = i.Product.Id;
                    detail.OrtherId = id;
                    detail.Quantity = i.Quantity;
                    detail.Price = i.Product.Price;
                    uow.OrderDetailsRepository.Add(detail);
                }
                uow.Commit();
                Session[Common.Constants.CartSession] = null;                
            }
            return RedirectToAction("Index", "Home");
        }

    }
}