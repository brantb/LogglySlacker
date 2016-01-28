using System.Collections.Generic;
using System.Linq;
using LogglySlackAzure.Model;

namespace LogglySlackAzure
{
    public class SlackMessageBuilder : IBuildSlackMessages
    {
        public SlackMessage BuildSlackMessage(LogglyAlert alert)
        {
            return new SlackMessage
                {
                    token = alert.token,
                    channel = alert.channel[0] == '#' ? alert.channel : "#" + alert.channel,
                    text = "",
                    icon_emoji = alert.icon_emoji
                };
        }

        public SlackAttachment GetSlackAttachment(LogglyAlert alert, IEnumerable<LogglyHit> hits)
        {
            return new SlackAttachment
                {
                    fallback = string.Empty,
                    title = string.Format("{0} entries from \'{1}\'", alert.num_hits, alert.alert_name),
                    title_link = alert.search_link,
                    text = string.Format("Between {0} and {1} UTC", alert.start_time, alert.end_time),
                    color = alert.color,
                    fields = GetAttachmentFields(hits).ToArray()
                };
        }

        private IEnumerable<SlackAttachmentField> GetAttachmentFields(IEnumerable<LogglyHit> hits)
        {
            return hits.Select(BuildAttachmentField);
        }

        private SlackAttachmentField BuildAttachmentField(LogglyHit hit)
        {
            return new SlackAttachmentField
                {
                    title = hit.logger,
                    value = hit.message.Split('\n').FirstOrDefault() ?? hit.message
                };
        }
    }
}