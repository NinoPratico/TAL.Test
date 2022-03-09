using System;

namespace TAL.DeathPremiumCalculator
{
    public class DeathPremiumCalculatorRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
        public double SumInsured { get; set; }
    }
    public class DeathPremiumCalculatorResponse
    {
        public double Premium { get; set; }
        public string Error { get; set; }

        public DeathPremiumCalculatorResponse(double _Premium = 0, string _Error = "")
        {
            Premium = _Premium;
            Error = _Error;
        }
    }
}
