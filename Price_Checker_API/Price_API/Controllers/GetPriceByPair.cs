using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Price_API.Services;
using Price_API.Models;

namespace Price_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetPriceByPair : Controller
    {
        public CheckPriceService _PriceService;
        public GetPriceByPair()
        {
           _PriceService = new CheckPriceService();
        }
         
        
        [HttpPost]
        public async Task<ActionResult<IEnumerable>> GetPrice([FromBody] RequestP2PData request)
        {

            //var data = await _PriceService.GetP2Price(request);
            //var periceBuyCripro = data.data[0].adv.price;
            //var cryptoBulk = float.Parse(request.fiatBulk) / float.Parse(periceBuyCripro);//Int32.Parse(data.data[0].adv.price);           
            //var b = _PriceService.GetPersendP2P(request);
            var test = await _PriceService.GetActualCostByPair();
            return Ok(test);
        }
    
    }

}
