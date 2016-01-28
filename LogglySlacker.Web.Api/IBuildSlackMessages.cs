using System.Collections.Generic;
using LogglySlacker.Model;

namespace LogglySlacker
{
    public interface IBuildSlackMessages
    {
        SlackMessage BuildSlackMessage(LogglyAlert alert);
        SlackAttachment GetSlackAttachment(LogglyAlert alert, IEnumerable<LogglyHit> hits);
    }
}