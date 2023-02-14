using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Price_API.Models;
using Price_API.Models.FiatCurrenctCostModel;
using System.Collections;
using System.Text;
using System.Text.Json.Serialization;

namespace Price_API.Services
{
    public class CheckPriceService
    {
     
        public async Task<ResponseP2PData> GetP2Price(string fiat, string cript, string tradeType)
        {
            //if (request==null || !AcssesFiat.Contains(request.InputFiat) || !AcssesCrypto.Contains(request.BuyCryptoType))
            //{
            //    return null;
            //}

            using(var client = new HttpClient())
            {            
                RequestDataJson repusetData= new RequestDataJson();
                repusetData.fiat = fiat;
                repusetData.asset = cript;
                repusetData.tradeType= tradeType;


                client.DefaultRequestHeaders.Add("Accept", "*/*");
                client.DefaultRequestHeaders.Add("x-trace-id", "4c3d6fce-a2d8-421e-9d5b-e0c12bd2c7c0");
                client.DefaultRequestHeaders.Add("x-ui-request-trace", "4c3d6fce-a2d8-421e-9d5b-e0c12bd2c7c0");
                var data = JsonConvert.SerializeObject(repusetData);
                var endpoint = new Uri("https://p2p.binance.com/bapi/c2c/v2/friendly/c2c/adv/search");
                var response = await client.PostAsync(endpoint, new StringContent(data, Encoding.UTF8, "application/json"));

                var responseContent = await response.Content.ReadAsStringAsync();
                ResponseP2PData responseData = JsonConvert.DeserializeObject<ResponseP2PData>(responseContent);

                return responseData;
                   
            }
                    
        }
        
        public async Task<float> GetPersendP2P(RequestP2PData request)
        {
            var inputFiatType = request.InputFiat;
            var outputFiatType = request.OutPutFiat;
            var P2PCripto = request.BuyCryptoType;
            var sellPrice = await GetP2Price(inputFiatType, P2PCripto, "SELL");
            var criptoCount = float.Parse(request.fiatBulk) / float.Parse(sellPrice.data[0].adv.price);
            var buyPrice = await GetP2Price(outputFiatType, P2PCripto, "BUY");
            var fiatCryptoCount = criptoCount * float.Parse(buyPrice.data[0].adv.price);
            return fiatCryptoCount;
        }

        public async Task<float> GetActualCostByPair()
        {
            using(var client = new HttpClient())
            {
                var data = await client.GetAsync("https://query1.finance.yahoo.com/v8/finance/chart/TRY=X?region=US&lang=en-US&includePrePost=false&interval=2m&useYfid=true&range=1d&corsDomain=finance.yahoo.com&.tsrc=finance");
                var responseContent = await data.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ActualCost>(responseContent);
                return response.chart.result[0].meta.regularMarketPrice;
            }
        }
        private string[] AcssesFiat = new string[] { "EUR", "USD", "TRY", "GEL", "UAH" };

        private string[] AcssesCrypto = new string[] {"USDT", "BTC", "BUSD", "BNB", "ETH", "UAH", "SHIB" };
    }
}
