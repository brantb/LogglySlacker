namespace LogglySlackAzure.Model
{
    public class LogglyAlert
    {
        public string token { get; set; }
        public string channel { get; set; }
        public string icon_emoji { get; set; }
        public string color { get; set; }

        public string alert_name { get; set; }
        public string search_link { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string query { get; set; }
        public string num_hits { get; set; }
        public string[] recent_hits { get; set; }
    }
}