using System.Diagnostics;
using System.Linq;
using LogglySlacker.Model;
using Newtonsoft.Json;
using RestSharp;

namespace LogglySlacker
{
    public class SlackClient : ISlackClient
    {
        private readonly RestClient _restClient;

        public SlackClient()
        {
            _restClient = new RestClient("https://slack.com/api");
        }

        public void PostMessage(SlackMessage message, params SlackAttachment[] attachments)
        {
            var request = new RestRequest("chat.postMessage", Method.POST) {RequestFormat = DataFormat.Json};
            request.AddHeader("Content-Type", "application/json");
            
            request.AddObject(message);

            if (attachments.Any())
            {
                request.AddParameter("attachments", JsonConvert.SerializeObject(attachments));
            }

            _restClient.ExecuteAsync(request, response => Trace.TraceInformation(string.Format("Slack response: {0}", response.Content)));
        }
    }
}