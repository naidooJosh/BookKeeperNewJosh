using BookKeeperNewJosh.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookKeeperNewJosh.Models
{
    public class UserProfileEdit
    {
        public int studentNo { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int totalrating { get; set; }
        public int ratingcount { get; set; }
        public float realRating
        {
            get
            {
                if (this.ratingcount == 0) return 0; else return totalrating / ratingcount;
            }
        }
        public virtual ICollection<Department> Departments { get; set; }
    }
}