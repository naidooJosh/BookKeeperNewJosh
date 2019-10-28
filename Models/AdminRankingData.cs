using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookKeeperNewJosh.Models
{
    public class AdminRankingData
    {
        public ArrayList top5 { get; set; }
        public ArrayList bottom5 { get; set; }

        public float averRank { get; set; }
    }
}