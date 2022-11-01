using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSOFOS.ViewModel
{
    public class CategoryViewModel
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public int RestaurantId { get; set; }


    }
}