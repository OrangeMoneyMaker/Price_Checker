namespace Price_API.Models
{
    public class RequestDataJson
    {
        public bool proMerchantAds { get; set; } = false;

        public int page { get; set; } = 1;

        public int rows { get; set; } = 10;

        public int[] payTypesotalRows { get; set; } = new int[] { };

        public int[] countries { get; set; } = new int[] { };

        public string asset { get; set; } = "USDT";

        public string fiat { get; set; } = "EUR";

        public string tradeType { get; set; } = "SELL";
    }
}
