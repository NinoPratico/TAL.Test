using System;

namespace TAL.DateHelpers
{
    public static class DateHelpers
    {
        public static int CalculateAge(this DateTime DateOfBirth)
        {
            int Result = 0;

            if (DateOfBirth <= DateTime.Now)
            {
                long Ticks = DateTime.Now.Subtract(DateOfBirth).Ticks;

                Result = new DateTime(Ticks).Year - 1;
            }

            return Result;
        }
    }
}
