using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Twilio2PagerDuty.Models;

namespace Twilio2PagerDuty.Controllers
{
    public class PagerDutyController : Controller
    {
        //
        // GET: /PagerDuty/

        protected static readonly HttpClient _httpclient = new HttpClient();


        public async Task<ActionResult> Index(string ServiceKey, string From, string To, string Body, string SmsSid)
        {
            var msg = "From: " + From + "\r\n" + Body;
            var pdEvent = new PagerDutyEvent() {
                service_key = ServiceKey,
                event_type = "trigger",
                description = msg.Substring(0,Math.Min(1024, msg.Length))
            };
            try
            {
                using (var response = await _httpclient.PostAsJsonAsync<PagerDutyEvent>("https://events.pagerduty.com/generic/2010-04-15/create_event.json", pdEvent))
                {
                    
                    if (response.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "PagerDuty incident created.";
                    }
                    else
                    {
                        ViewBag.Message = "failed to create PagerDuty incident - statusCode " + response.StatusCode.ToString();
                    }
                }
            }
            catch
            {
                ViewBag.Message = "failed to create PagerDuty incident";
            }
            return View();
        }


    }
}
