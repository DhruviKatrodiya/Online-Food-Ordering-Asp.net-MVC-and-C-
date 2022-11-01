using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSOFOS.Models
{
    public class gmail
    {
        [Required(ErrorMessage = "Enter Your Email")]
        [Display(Name = "To")]
        public string To { get; set; }

        [Required(ErrorMessage = "Enter Email From")]
        [Display(Name = "From")]
        public string From { get; set; }

        [Required(ErrorMessage = "Enter Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Enter Body")]
        public string Body { get; set; }

    }
}