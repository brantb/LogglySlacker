LogglySlacker
===================

A small service to forward Loggly Alerts to Slack. Doesn't require any configuration of the app or any credentials, all parameters are simply entered in the URL of the Loggly config screen like any other Slack integration.

## Usage

In your Loggly Alerting Endpoint configure the URL as:  
{LogglySlackerHost}/?token={Slack Token}&channel={Slack channel}&icon_emoji=:grey_exclamation:&color={good|warning|danger}

## Advanced ##

**Fields included in the Loggly webhook post body**

```Javascript
{
  "alert_name" : "Service ERROR",
  "alert_description" : "",
  "edit_alert_link" : "https://{account}.loggly.com/alerts/edit/1",
  "source_group" : "N/A",
  "start_time" : "Jan 27 01:15:35",
  "end_time" : "Jan 27 01:45:35",
  "search_link" : "https://{account}.loggly.com/search/?terms=tag%3AService+AND+json.level%3A%22ERROR%22&source_group=&savedsearchid=142103&from=2016-01-27T01%3A15%3A35Z&until=2016-01-27T01%3A45%3A35Z",
  "query" : "tag:Service AND json.level:\"ERROR\" ",
  "num_hits" : 1,
  "recent_hits" : [
      "{\"level\":\"ERROR\",\"time\":\"2016-01-27T01:45:09.2052851+00:00\",\"machine\":\"RD000D3A3131D5\",\"process\":\"w3wp\",\"thread\":\"68\",\"message\":\"Expected hex 0x in '{0}'.\",\"logger\":\"IQ.ProductSubscriptions.Web.Api.Common.ProductSubscriptionsApiErrorPipeline\",\"exception\":{\"message\":\"ERROR\",\"type\":\"FormatException\",\"stackTrace\":\"A stacktrace\"}}"
  ],
  "owner_username" : "Mr. Manager",
  "owner_subdomain" : "{company}",
  "owner_email" : "user@company.com",
  "alert_snoozed" : false
}
```

The 'recent_hits' are individually deserialized before being passed into the template.
