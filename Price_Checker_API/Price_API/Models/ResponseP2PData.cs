namespace Price_API.Models
{
    public class ResponseP2PData
    {
        public string code { get; set; }

        public string message { get; set; }

        public string massegeDetail { get; set; }

        public List<P2PData> data { get; set; }
    }

}
