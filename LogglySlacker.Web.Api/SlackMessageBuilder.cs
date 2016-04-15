using System.Collections.Generic;
using System.Linq;
using LogglySlacker.Model;

namespace LogglySlacker
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
                    icon_emoji = alert.icon_emoji,
                    as_user = false,
                    username = "Loggly",
                    unfurl_media = false
                };
        }

        public SlackAttachment GetSlackAttachment(LogglyAlert alert, IEnumerable<LogglyHit> hits)
        {
            return new SlackAttachment
                {
                    fallback = string.Empty,
                    title = $"{alert.num_hits} entries from \'{alert.alert_name}\'",
                    title_link = alert.search_link,
                    text = $"Between {alert.start_time} and {alert.end_time} UTC",
                    color = alert.color,
                    fields = GetAttachmentFields(hits).ToArray()
                };
        }

        private static IEnumerable<SlackAttachmentField> GetAttachmentFields(IEnumerable<LogglyHit> hits)
        {
            return hits.Select(BuildAttachmentField);
        }

        private static SlackAttachmentField BuildAttachmentField(LogglyHit hit)
        {
            return new SlackAttachmentField
                {
                    title = hit.logger,
                    value = hit.message?.Split('\n').FirstOrDefault() ?? hit.message
                };
        }
    }
}