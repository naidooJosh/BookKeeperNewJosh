using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookKeeperNewJosh.Models
{
    public class ShippingDetails
    {
        public string shippingDetailID { get; set; }
        [Required]
        public string studentNo { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string zipCode { get; set; }
        [Required]
        public int orderID { get; set; }
       
        public decimal amountPaid { get; set; }
        [Required]
        public string paymentType { get; set; }

      
    }
}