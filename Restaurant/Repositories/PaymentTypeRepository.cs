using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Repositories
{
    public class PaymentTypeRepository
    {
        private RestaurantEntities objRestaurantEntities;
        
        public PaymentTypeRepository()
        {
            objRestaurantEntities = new RestaurantEntities();
        }
        public IEnumerable<SelectListItem> GetAllPaymentType()
        {
            IEnumerable<SelectListItem> objselectListItems = new List<SelectListItem>();
            objselectListItems = (from obj in objRestaurantEntities.PaymentTypes
                                  select new SelectListItem()
                                  { 
                                      Text = obj.PaymentType1,
                                      Value = obj.PaymentTypeId.ToString(),
                                      Selected = true
                                  }
                                  ).ToList();
            return objselectListItems;

        }
    }
}