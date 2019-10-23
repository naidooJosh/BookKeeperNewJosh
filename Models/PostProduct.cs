using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookKeeperNewJosh.Models
{
    public class PostProduct
    {
        public int listingID { get; set; }
        [Required]
        public decimal listedPrice { get; set; }
        [Required(ErrorMessage = "Please enter the book amount")]
        public decimal soldPrice { get; set; }
        public int condition { get; set; }
        [Required(ErrorMessage = "Please enter the book title")]
        public string title { get; set; }
        [Required(ErrorMessage = "Please enter the author's name")]
        public string author { get; set; }
        [Required(ErrorMessage = "Please enter the book title")]
        public string studentNumber { get; set; }
        [Required]
        public string moduleCode { get; set; }
        [Required]        
        public byte[] photo { get; set; }
        [Required(ErrorMessage = "Please Add book photo")]
        public string description { get; set; }
        [Required(ErrorMessage = "Please add book description")]
        public bool isSold { get; set; }
        public bool isQuickSell { get; set; }
        public Nullable<float> perDrop { get; set; }
        public Nullable<int> duration { get; set; }
    }
}