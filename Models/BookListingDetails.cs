using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookKeeperNewJosh.Models
{
    public class BookListingDetails
    {
        public int listingID { get; set; }
        [Required]
        public decimal listedPrice { get; set; }
        public decimal soldPrice { get; set; }
        [Required]
        public int condition { get; set; }
        [Required(ErrorMessage ="Please enter the book title")]
        public string title { get; set; }
        [Required(ErrorMessage = "Please enter the author's name")]
        public string author { get; set; }
        [Required(ErrorMessage = "Please enter the book title")]
        public string studentNumber { get; set; }
        
        [Required]

        public string moduleCode { get; set; }
        [Required]
        public SelectList department { get; set; }
        public byte[] photo { get; set; }
        public string description { get; set; }
        public bool isSold { get; set; }
        public bool isQuickSell { get; set; }
        public Nullable<float> perDrop { get; set; }
        public Nullable<int> duration { get; set; }
    }

 
}