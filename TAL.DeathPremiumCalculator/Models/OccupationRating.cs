namespace TAL.DeathPremiumCalculator
{
    public class OccupationRating
    {
        public string Rating { get; set; }
        public double Factor { get; set; }

        public OccupationRating(string _Rating = "", double _Factor = 0)
        {
            Rating = _Rating;
            Factor = _Factor;
        }
    }
}
