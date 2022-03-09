using System;
using System.Collections.Generic;
using TAL.DateHelpers;

namespace TAL.DeathPremiumCalculator
{
    public class DeathPremiumCalculatorService : IDeathPremiumCalculatorService
    {
        // Assumption: For the sake of simplicity, these values hard coded for this test.
        // They could be stored in a db and queried from the database.
        // The Repository could  be injected into this service class.

        public List<Occupation> Occupations { get; set; }
        public List<OccupationRating> OccupationRatings { get; set; }


        public DeathPremiumCalculatorService()
        {
            Occupations =
                new List<Occupation>()
                {
                    new Occupation(OcccupationName.Author, OccupationRatingName.WhiteCollar),
                    new Occupation(OcccupationName.Cleaner, OccupationRatingName.LightManual),
                    new Occupation(OcccupationName.Doctor, OccupationRatingName.Professional),
                    new Occupation(OcccupationName.Farmer, OccupationRatingName.HeavyManual),
                    new Occupation(OcccupationName.Florist, OccupationRatingName.LightManual),
                    new Occupation(OcccupationName.Mechanic, OccupationRatingName.HeavyManual),
                };

            OccupationRatings =
                new List<OccupationRating>()
                {
                    new OccupationRating(OccupationRatingName.HeavyManual, 1.75),
                    new OccupationRating(OccupationRatingName.LightManual, 1.50),
                    new OccupationRating(OccupationRatingName.Professional, 1.00),
                    new OccupationRating(OccupationRatingName.WhiteCollar, 1.25)
                };
        }

        public IEnumerable<Occupation> GetOccupations()
        {
            return Occupations;
        }

        public DeathPremiumCalculatorResponse CalcMonthlyPremium(DeathPremiumCalculatorRequest Request)
        {
            DeathPremiumCalculatorResponse Result = new();

            if (string.IsNullOrEmpty(Request.Name))
                Result.Error = "Name is required";
            else if (string.IsNullOrEmpty(Request.Occupation))
                Result.Error = "Occupation is required";
            else if (Request.SumInsured <= 0)
                Result.Error = "Sum Insured is negative";
            else if (Request.Age < 1)
                Result.Error = "Age is required";
            else
            {
                Dictionary<string, string> dOccupations = new();
                Dictionary<string, double> dOccupationRatings = new();

                foreach (Occupation Entity in Occupations)
                    dOccupations.Add(Entity.Name, Entity.Rating);

                foreach (OccupationRating Entity in OccupationRatings)
                    dOccupationRatings.Add(Entity.Rating, Entity.Factor);

                if (dOccupations.TryGetValue(Request.Occupation, out string OccupationRating))
                {
                    if (dOccupationRatings.TryGetValue(OccupationRating, out double OccupationRatingFactor))
                    {
                        Result.Premium = (Request.SumInsured * OccupationRatingFactor * Request.Age) / 1000 * 12;
                    }
                    else
                    {
                        Result.Error = "Occupation Rating is in-valid";
                    }
                }
                else
                {
                    Result.Error = "Occupation is in-valid";
                }
            }

            return Result;
        }
    }
}
