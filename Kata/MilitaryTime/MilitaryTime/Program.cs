using System;

namespace MilitaryTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TimeConversion("07:56:30PM"));
        }

        public static string TimeConversion(string s)
        {
            string amPm = s.Substring(s.Length - 2, 2);
            string hour = s.Substring(0, 2);
            string remaining = s.Substring(2, s.Length - 2);

            if (amPm == "PM")
            {
                if (!hour.Equals("12"))
                {
                    string newHour;
                    int hourInt = Int32.Parse(hour);
                    hourInt += 12;
                    if (hourInt < 10)
                    {
                        newHour = string.Concat('0', Char.Parse(hourInt.ToString()));
                    }
                    else
                    {
                        newHour = string.Concat(hourInt.ToString());
                    }
                    string newString = string.Concat(newHour, remaining.Substring(0, remaining.Length - 2));
                    return newString;
                }
                else
                {
                    return s.Substring(0, s.Length - 2);
                }

            }
            else
            {
                string anotherNewString = string.Empty;
                string anotherNewHour = string.Empty;
                if (hour.Equals("12"))
                {
                    anotherNewHour = "00";
                    anotherNewString = string.Concat(anotherNewHour, remaining);
                }
                else
                {
                    anotherNewString = s;
                }
                return anotherNewString.Substring(0, (anotherNewString.Length - 2));
            }

        }
    }
}
