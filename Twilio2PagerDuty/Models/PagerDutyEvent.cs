using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twilio2PagerDuty.Models
{
    public class PagerDutyEvent
    {
        public string service_key { get; set; }
        public string event_type { get; set; }
        public string description { get; set; }
        public dynamic details { get; set; }
    }
}