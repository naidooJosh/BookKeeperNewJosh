using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookKeeperNewJosh.Models
{
    public class DepartmentDetails
    {
        [Required]
        public int departmentID { get; set; }
        [Required]
        public string name { get; set; }
    }
}