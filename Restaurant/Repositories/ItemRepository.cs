using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Repositories
{
    public class ItemRepository
    {
        private RestaurantEntities objRestaurantEntities;

        public ItemRepository()
        {
            objRestaurantEntities = new RestaurantEntities();
        }
        public IEnumerable<SelectListItem> GetAllItems()
        {
            IEnumerable<SelectListItem> objselectListItems = new List<SelectListItem>();
            objselectListItems = (from obj in objRestaurantEntities.Items
                                  select new SelectListItem()
                                  {
                                      Text = obj.ItemName,
                                      Value = obj.ItemId.ToString(),
                                      Selected = true
                                  }
                                  ).ToList();
            return objselectListItems;

        }
    }
}