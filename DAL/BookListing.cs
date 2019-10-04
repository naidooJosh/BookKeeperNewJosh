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
    
    public partial class BookListing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BookListing()
        {
            this.Carts = new HashSet<Cart>();
        }
    
        public int listingID { get; set; }
        public decimal listedPrice { get; set; }
        public decimal soldPrice { get; set; }
        public int condition { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string studentNumber { get; set; }
        public string moduleCode { get; set; }
        public byte[] photo { get; set; }
        public string description { get; set; }
        public bool isSold { get; set; }
        public bool isQuickSell { get; set; }
        public Nullable<float> perDrop { get; set; }
        public Nullable<int> duration { get; set; }
    
        public virtual Module Module { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
