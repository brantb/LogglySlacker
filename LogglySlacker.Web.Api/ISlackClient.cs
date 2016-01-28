using LogglySlacker.Model;

namespace LogglySlacker
{
    public interface ISlackClient
    {
        void PostMessage(SlackMessage message, params SlackAttachment[] attachments);
    }
}