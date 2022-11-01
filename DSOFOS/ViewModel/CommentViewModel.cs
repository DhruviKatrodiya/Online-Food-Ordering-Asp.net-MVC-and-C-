using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSOFOS.ViewModel
{
    public class CommentViewModel
    {

        public int ReviewId { get; set; }
        public int Rate { get; set; }
        public string Remarks { get; set; }
       // public int UserId { get; set; }
        public int MenuItemId { get; set; }
        public DateTime CreatedAt { get; set; }

        public string UserName { get; set; }

    }
}