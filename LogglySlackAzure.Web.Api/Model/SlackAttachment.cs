namespace LogglySlackAzure.Model
{
    public class SlackAttachment
    {
        public string fallback { get; set; }
        public string color { get; set; }
        public string title { get; set; }
        public string title_link { get; set; }
        public string text { get; set; }
        public SlackAttachmentField[] fields { get; set; }
    }
}