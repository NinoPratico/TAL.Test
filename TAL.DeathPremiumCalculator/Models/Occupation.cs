namespace TAL.DeathPremiumCalculator
{
    public class Occupation
    {
        public string Name { get; set; }
        public string Rating { get; set; }

        public Occupation(string _Name = "", string _Rating = "")
        {
            Name = _Name;
            Rating = _Rating;
        }
    }
}
