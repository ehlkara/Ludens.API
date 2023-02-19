using Ludens.BusinessLogic.Abstract;
using Ludens.Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;

namespace Ludens.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LudensController : CustomBaseController
    {
        private readonly ILudensBLL _ludensBLL;

        public LudensController(ILudensBLL ludensBLL)
        {
            _ludensBLL = ludensBLL;
        }

        [HttpGet(template: "Calculate_Daily_Proccess")]
        public async Task<IActionResult> CalculateDailyProccess([FromQuery] string fundCode)
        {
            return CreateActionResultInstance(await _ludensBLL.CalculateDailyProccessAsync(fundCode));
        }

        [HttpGet(template: "Calculate_Weekly_Proccess")]
        public async Task<IActionResult> CalculateWeeklyProccess([FromQuery] string fundCode)
        {
            return CreateActionResultInstance(await _ludensBLL.CalculateWeeklyProccessAsync(fundCode));
        }

        [HttpGet(template: "Calculate_Monthly_Proccess")]
        public async Task<IActionResult> CalculateMonthlyProccess([FromQuery] string fundCode)
        {
            return CreateActionResultInstance(await _ludensBLL.CalculateMonthlyProccessAsync(fundCode));
        }

        [HttpGet(template: "Calculate_Quarterly_Of_Month_Proccess")]
        public async Task<IActionResult> CalculateQuarterlyOfMonthProccess([FromQuery] string fundCode)
        {
            return CreateActionResultInstance(await _ludensBLL.CalculateQuarterlyOfMonthProccessAsync(fundCode));
        }
    }
}
