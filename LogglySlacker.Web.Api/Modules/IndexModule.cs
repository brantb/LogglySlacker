using System.Collections.Generic;
using LogglySlacker.Model;
using Nancy;
using Nancy.ModelBinding;
using Newtonsoft.Json;

namespace LogglySlacker.Modules
{
    public class IndexModule : NancyModule
    {
        private readonly IBuildSlackMessages _slackMessageBuilder;
        private readonly ISlackClient _slackClient;

        public IndexModule(IBuildSlackMessages slackMessageBuilder,
            ISlackClient slackClient)
        {
            _slackMessageBuilder = slackMessageBuilder;
            _slackClient = slackClient;

            Get["/"] = _ => "pong";
            Post["/"] = _ => PostAlert();
        }

        private dynamic PostAlert()
        {
            Request.Headers.ContentType = "application/json"; // Loggly sends the Content-Type as text/plain even though it is clearly json...

            var logglyAlert = this.Bind<LogglyAlert>();
            var logglyHits = ParseLogglyHits(logglyAlert.recent_hits);

            var slackMessage = _slackMessageBuilder.BuildSlackMessage(logglyAlert);
            var attachments = new[] { _slackMessageBuilder.GetSlackAttachment(logglyAlert, logglyHits) };
            
            _slackClient.PostMessage(slackMessage, attachments);

            return HttpStatusCode.OK;
        }

        private static IEnumerable<LogglyHit> ParseLogglyHits(IEnumerable<string> encodedHits)
        {
            foreach (var encodedHit in encodedHits)
            {
                var escapedHit = encodedHit.Replace("\\", "\\\\").Replace("\r\n", "\\r\\n");
                yield return JsonConvert.DeserializeObject<LogglyHit>(escapedHit);
            }
        }
    }
}