//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DSOFOS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payment()
        {
            this.Orders = new HashSet<Order>();
        }

        public int PaymentId { get; set; }
        [Required(ErrorMessage = "Enter  Full Name")]
        [Display(Name = "FullName")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter  Card Number")]
        [Display(Name = "CardNo")]
        [MaxLength(14)]
        public string CardNo { get; set; }
        [Required(ErrorMessage = "Choose date of ExpiryDate")]
        [Display(Name = "ExpiryDate")]
        [DataType(DataType.Date)]
        public string ExpiryDate { get; set; }
        [Required(ErrorMessage = "Enter CVV Number")]
        [Display(Name = "CvvNo")]
        public Nullable<int> CvvNo { get; set; }
        //[Required(ErrorMessage = "Enter Address")]
        //[Display(Name = "Address")]
        public string Address { get; set; }
       // [Required(ErrorMessage = "Enter PaymentMode")]
        public string PaymentMode { get; set; }
        //[Required(ErrorMessage = "Enter Top display Amount")]
        public Nullable<int> Amount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}