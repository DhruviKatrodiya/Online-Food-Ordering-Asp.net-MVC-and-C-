using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSOFOS.ViewModel
{
    public class MenuItemViewModel
    {

        public int MenuItemId { get; set; }
        public int CategoryId { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemImage { get; set; }
        public string MenuItemDescription { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

    }
}