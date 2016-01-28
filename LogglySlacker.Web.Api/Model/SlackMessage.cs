namespace LogglySlacker.Model
{
    public class SlackMessage
    {
        public string token { get; set; }
        public string channel { get; set; }
        public string text { get; set; }
        public string icon_emoji { get; set; }

        public bool as_user { get { return false; } }
        public string username { get { return "Loggly"; } }
        public bool unfurl_media { get { return false; } }
    }
}