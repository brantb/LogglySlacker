using System.Collections.Generic;
using LogglySlackAzure.Model;

namespace LogglySlackAzure
{
    public interface IBuildSlackMessages
    {
        SlackMessage BuildSlackMessage(LogglyAlert alert);
        SlackAttachment GetSlackAttachment(LogglyAlert alert, IEnumerable<LogglyHit> hits);
    }
}