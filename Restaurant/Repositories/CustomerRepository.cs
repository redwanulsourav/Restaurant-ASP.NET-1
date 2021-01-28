using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Repositories
{
    public class CustomerRepository
    {
        private RestaurantEntities objRestaurantEntities;

        public CustomerRepository()
        {
            objRestaurantEntities = new RestaurantEntities();
        }
        public IEnumerable<SelectListItem> GetAllItems()
        {
            IEnumerable<SelectListItem> objselectListItems = new List<SelectListItem>();
            objselectListItems = (from obj in objRestaurantEntities.Customers
                                  select new SelectListItem()
                                  {
                                      Text = obj.CustomerName,
                                      Value = obj.CustomerId.ToString(),
                                      Selected = true
                                  }
                                  ).ToList();
            return objselectListItems;

        }
    }
}