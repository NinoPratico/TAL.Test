using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using TAL.DeathPremiumCalculator;

namespace TAL.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeathPremiumCalculatorController : ControllerBase
    {
        private readonly ILogger<DeathPremiumCalculatorController> _logger;
        private readonly IDeathPremiumCalculatorService _DeathPremiumCalculatorService;

        public DeathPremiumCalculatorController(ILogger<DeathPremiumCalculatorController> logger,
                                                IDeathPremiumCalculatorService DeathPremiumCalculatorService)
        {
            _logger = logger;
            _DeathPremiumCalculatorService = DeathPremiumCalculatorService;
        }

        [HttpGet]
        [Route("Init")]
        public IEnumerable<Occupation> GetInit()
        {
            return _DeathPremiumCalculatorService.GetOccupations();
        }

        [HttpPost]
        [Route("CalcPremium")]
        public DeathPremiumCalculatorResponse PostCalcPremium(DeathPremiumCalculatorRequest Request)
        {
            return _DeathPremiumCalculatorService.CalcMonthlyPremium(Request);
        }
    }
}
