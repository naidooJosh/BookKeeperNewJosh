//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookKeeperNewJosh.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShippingDetail
    {
        public string shippingDetailID { get; set; }
        public int studentNo { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zipCode { get; set; }
        public int orderID { get; set; }
        public decimal amountPaid { get; set; }
        public string paymentType { get; set; }
    
        public virtual User User { get; set; }
    }
}
