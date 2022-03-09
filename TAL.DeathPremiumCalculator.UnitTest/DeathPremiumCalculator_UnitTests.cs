using NUnit.Framework;
using System;
using TAL.DateHelpers;
using TAL.DeathPremiumCalculator;

namespace TAL.PremiumCalculator.UnitTest
{
    public class DeathPremiumCalculator_UnitTests
    {
        private IDeathPremiumCalculatorService _DeathPremiumCalculatorService { get; set; }

        [SetUp]
        public void Setup()
        {
            _DeathPremiumCalculatorService = new DeathPremiumCalculatorService();
            _DeathPremiumCalculatorService.Occupations.Add(new Occupation("NoRatingFactor", ""));
        }

        [TearDown]
        public void Teardown()
        {
        }

        [TestCase("Test", 100000, OcccupationName.Author, "07/03/2022", 0)]
        [TestCase("Test", 100000, OcccupationName.Author, "07/03/2021", 1500)]
        [TestCase("Test", 100000, OcccupationName.Author, "01/01/1982", 60000)]
        [TestCase("Test", 100000, OcccupationName.Cleaner, "01/01/1982", 72000)]
        [TestCase("Test", 100000, OcccupationName.Doctor, "01/01/1982", 48000)]
        [TestCase("Test", 100000, OcccupationName.Farmer, "01/01/1982", 84000)]
        [TestCase("Test", 100000, OcccupationName.Florist, "01/01/1982", 72000)]
        [TestCase("Test", 100000, OcccupationName.Mechanic, "01/01/1982", 84000)]
        public void CalcMonthlyPremium(string _Name, double _SumInsured, string _Occupation, string _DateOfBirth, double _ExpectedResult)
        {
            DeathPremiumCalculatorRequest Request =
                new()
                {
                    Age = DateTime.Parse(_DateOfBirth).CalculateAge(),
                    Name = _Name,
                    Occupation = _Occupation,
                    SumInsured = _SumInsured
                };

            DeathPremiumCalculatorResponse Response = _DeathPremiumCalculatorService.CalcMonthlyPremium(Request);

            Assert.AreEqual(_ExpectedResult, Response.Premium);
        }

        [TestCase("Test.1", -10000, OcccupationName.Mechanic, 1, 0, "Sum Insured is negative")]
        [TestCase("Test.2", 100000, "NoOccupation", 1, 0, "Occupation is in-valid")]
        [TestCase("Test.3", 100000, "NoRatingFactor", 1, 0, "Occupation Rating is in-valid")]
        public void CalcMonthlyPremium_ThrowsException(string _Name, double _SumInsured, string _Occupation, int _Age, double _ExpectedPremium, string _ExpectedError)
        {
            DeathPremiumCalculatorRequest Request =
                new()
                {
                    Age = _Age,
                    Name = _Name,
                    Occupation = _Occupation,
                    SumInsured = _SumInsured
                };

            DeathPremiumCalculatorResponse Response = _DeathPremiumCalculatorService.CalcMonthlyPremium(Request);

            Assert.AreEqual(_ExpectedPremium, Response.Premium);
            Assert.AreEqual(_ExpectedError, Response.Error);
        }
    }
}