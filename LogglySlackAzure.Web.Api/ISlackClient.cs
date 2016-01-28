using LogglySlackAzure.Model;

namespace LogglySlackAzure
{
    public interface ISlackClient
    {
        void PostMessage(SlackMessage message, params SlackAttachment[] attachments);
    }
}