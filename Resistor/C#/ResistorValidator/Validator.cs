using System;
using System.Collections.Generic;
using System.Linq;

namespace ResistorValidator
{
    public class Validator
    {
        protected Dictionary<string, int> _valueMap = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase)
        {
            { "Black", 0 },
            { "Brown", 1 },
            { "Red", 2 },
            { "Orange", 3 },
            { "Yellow", 4 },
            { "Green", 5 },
            { "Blue", 6 },
            { "Violet", 7 },
            { "Gray", 8 },
            { "White", 9 },
            { "Gold", -1 },
            { "Silver", -2 }
        };

        protected Dictionary<string, int> _toleranceMap = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase)
        {
            { "Brown", 1 },
            { "Red", 2 },
            { "Gold", 5 },
            { "Silver", 10 },
            { "None", 20 }
        };

        public bool IsInRange(string[] stripeColor, double measuredOhms)
        {
            double nominalOhms = GetOhms(stripeColor.Take(stripeColor.Length - 1).ToArray());
            double toleranceOhms = GetTolerance(nominalOhms, stripeColor.Last());

            double minOhms = Math.Round(nominalOhms - toleranceOhms, 2);
            double maxOhms = Math.Round(nominalOhms + toleranceOhms, 2);

            return measuredOhms >= minOhms && measuredOhms <= maxOhms;
        }

        protected double GetOhms(string[] stripeColor)
        {
            double nominal = 0;
            foreach (string color in stripeColor.Take(stripeColor.Length - 1))
            {
                int digit = GetValue(_valueMap, color);
                nominal = nominal * 10 + digit;
            }

            int multiplier = GetValue(_valueMap, stripeColor.Last());
            nominal *= Math.Pow(10, multiplier);

            return nominal;
        }

        protected double GetTolerance(double nominalOhms, string toleranceColor)
        {
            int percent = GetValue(_toleranceMap, toleranceColor, _toleranceMap["None"]);
            return nominalOhms * (percent / 100.0);
        }

        protected int GetValue(Dictionary<string, int> map, string key, int defaultValue = -1)
        {
            int value;
            if (!map.TryGetValue(key, out value))
                value = defaultValue;

            return value;
        }
    }
}
