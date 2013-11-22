Twilio2PagerDuty
================

Simple web app that triggers PagerDuty incidents via SMS sent to a Twilio number

To use:

1. Clone the repository.
2. Build and deploy the website to the Internet
3. Sign into PagerDuty and create a new generic API service and take note of your new service_key
4. Create a PagerDuty escalation policy for your new service
5. Sign into Twilio and create a new number for incoming SMS messaging.
6. Set the Twilio Request URL to be the URL of the site deployed in step 2 adding the path, "PagerDuty/" followed by your PagerDuty service key from step 3.

i.e. https://alerts.mysite.com/PagerDuty/<MyPagerDutyServiceKey>

Enjoy
-Craig
