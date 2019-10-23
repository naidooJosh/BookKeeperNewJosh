using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookKeeperNewJosh.Models
{
    public class DeletePost
    {
        public int listingID { get; set; }
        [Required]
        public decimal listedPrice { get; set; }
        [Required]
        public decimal soldPrice { get; set; }
        public int condition { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string author { get; set; }
        [Required]
        public string studentNumber { get; set; }
        [Required]
        public string moduleCode { get; set; }
        [Required]
        public byte[] photo { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public bool isSold { get; set; }
        public bool isQuickSell { get; set; }
        public Nullable<float> perDrop { get; set; }
        public Nullable<int> duration { get; set; }
    }
}