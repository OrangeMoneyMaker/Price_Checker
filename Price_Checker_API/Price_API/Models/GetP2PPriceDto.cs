namespace Price_API.Models
{
    public class GetP2PPriceDto
    {
        public string Asset { get; set; } = string.Empty;

        public string Fiat { get; set; } = string.Empty;

        public string TradeType { get; set; } = string.Empty;
    }
}
