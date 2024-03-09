using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuildingTool.Models
{
    public abstract class Timeline
    {
        private static double _tick = 0.0;
        public static double Tick
        {
            get => _tick;
            set
            {
                _tick = CustomRound(value, 1);
            }
        }

        /// <summary>
        /// Rounds the specified value with a custom rule for decimal places.
        /// </summary>
        /// <param name="value">The value to be rounded.</param>
        /// <param name="decimalPlaces">The number of decimal places.</param>
        /// <returns>The rounded value according to the custom rules.</returns>
        public static double CustomRound(double value, int decimalPlaces)
        {
            // Calculation of the factor for decimal places
            double factor = Math.Pow(10, decimalPlaces);

            // Rounding the value and adjusting the decimal places
            double roundedValue = Math.Round(value * factor) / factor;

            // Checking and adjusting the digit of the decimal place
            int lastDigit = (int)(roundedValue * 10) % 10;
            if (lastDigit % 2 == 1) // If the digit is odd
            {
                roundedValue = Math.Floor(roundedValue * 10) / 10.0; // Round to the previous tenth place
                roundedValue += 0.2; // Add the next allowed digit
            }

            return roundedValue;
        }
    }
}
