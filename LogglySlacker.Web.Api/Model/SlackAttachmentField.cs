namespace LogglySlacker.Model
{
    public class SlackAttachmentField
    {
        public string title { get; set; }
        public string value { get; set; }
        public bool @short { get { return false; } }
    }
}