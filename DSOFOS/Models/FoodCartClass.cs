using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSOFOS.Models
{
    public class FoodCartClass
    {
        //public MenuItem Menu { get; set; }
        //public int Quantity { get; set; }
        //public FoodCartClass(MenuItem menuItem, int quantity)
        //{
        //    Menu = menuItem;
        //    Quantity = quantity;
        //}

        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public float Amount { get; set; }
        public int Quantity { get; set; }
        public float Bill { get; set; }
        public int UserId { get; set; }

        public string Status { get; set; }

        

    }
}