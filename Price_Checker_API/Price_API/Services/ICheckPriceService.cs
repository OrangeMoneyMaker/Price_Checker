using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Price_API.Services
{
    public interface ICheckPriceService
    {
        Task<ActionResult<IEnumerable>> GetP2Price();
    }
}
