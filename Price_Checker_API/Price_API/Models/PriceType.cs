namespace Price_API.Models
{
    public class PriceType
    {
        public string asset { get; set; }

        public string tradeType { get; set; }

        public string fiatUnit { get; set; }

        public string price { get; set; }

        public string surplusAmount { get; set; }

        public string maxSingleTransAmount { get; set; }

        public string minSingleTransAmount { get; set; }
        public List<TradeData> tradeMethods { get; set; }
    }
}
