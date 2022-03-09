using System.Collections.Generic;

namespace TAL.DeathPremiumCalculator
{
    public interface IDeathPremiumCalculatorService
    {
        List<Occupation> Occupations { get; set; }
        List<OccupationRating> OccupationRatings { get; set; }

        IEnumerable<Occupation> GetOccupations();
        DeathPremiumCalculatorResponse CalcMonthlyPremium(DeathPremiumCalculatorRequest Request);
    }
}
