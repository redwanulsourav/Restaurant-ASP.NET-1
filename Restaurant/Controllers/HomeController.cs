using Restaurant.Models;
using Restaurant.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private RestaurantEntities obj = new RestaurantEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(Signup log)
        {
            var login = obj.Signups.Where(x => x.username == log.username && x.password == log.password).FirstOrDefault();
            if(login != null)
            {
                Session["username"] = log.username;
                return RedirectToAction("ManagerProfile");
            }
            else
            {
                ViewBag.Errormessage = "Username or Password is incorrect";
                return View("Login", log);
            }

            
        }

        [HttpGet]
        public ActionResult ManagerProfile()
        {
            var username = Session["username"];
            var mang = obj.Signups.Where(x => x.username == username).FirstOrDefault();
            return View(mang);
        }

        [HttpGet]
        public ActionResult AddItems()
        {
            Item[] items = obj.Items.ToArray();
            return View();
        }

        [HttpPost]

        public ActionResult AddItems(Item item)
        {
            Item item1 = new Item();
            item1.ItemName = item.ItemName;
            item1.ItemPrice = item.ItemPrice;

            obj.Items.Add(item1);
            obj.SaveChanges();
            return RedirectToAction("ItemList");


        }

        [HttpGet]
        public ActionResult ItemList()
        {
            return View(obj.Items.ToList());
        }

        public ActionResult Order()
        {
            CustomerRepository customerRepository = new CustomerRepository();
            ItemRepository itemRepository = new ItemRepository();
            PaymentTypeRepository paymentTypeRepository = new PaymentTypeRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (customerRepository.GetAllCustomers(),itemRepository.GetAllItems(),paymentTypeRepository.GetAllPaymentType());
            return View(objMultipleModels);
        }

        public JsonResult GetItemPrice(int itemid)
        {
            decimal unitprice = obj.Items.Single(model => model.ItemId == itemid).ItemPrice;
            return Json(unitprice, JsonRequestBehavior.AllowGet); 
        }
    }
}