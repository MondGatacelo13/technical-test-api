using System;
using System.Collections.Generic;

namespace technical_test_api.Models
{
    public partial class Talktoguests
    {
        public string ParkCode { get; set; }
        public string PmEmail { get; set; }
        public string Category { get; set; }
        public string GuestName { get; set; }
        public string GuestMobile { get; set; }
        public string ResId { get; set; }
        public string Arrived { get; set; }
        public string Depart { get; set; }
        public string NightsThisRes { get; set; }
        public string RevenueThisRes { get; set; }
        public string PriorVisits { get; set; }
        public string PriorRevenue { get; set; }
        public string PriorNights { get; set; }
        public string MemberStatus { get; set; }
        public string AreaName { get; set; }
        public string PrevResId { get; set; }
        public string PrevNps { get; set; }
        public string PrevNpsComment { get; set; }
        public string HaveVisited { get; set; }
    }
}
