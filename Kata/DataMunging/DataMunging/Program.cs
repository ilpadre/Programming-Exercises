using System;
using System.IO;


namespace DataMunging
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MinTemperatureRange();
        }

        private static void MinTemperatureRange()
        {
            using var temperatures = new StreamReader("weather.dat.csv");
            if (!temperatures.EndOfStream)
            {
                // skip header line
                temperatures.ReadLine();
            }

            var high = 0;
            var low = 200;
            var diff = 200;
            var day = 0;
            while (!temperatures.EndOfStream)
            {
                var line = temperatures.ReadLine();
                var items = line.Split(',');
                var thisHigh = Convert.ToInt32(items[1]);
                var thisLow = Convert.ToInt32(items[2]);
                if (diff > thisHigh - thisLow)
                {
                    diff = thisHigh - thisLow;
                    day = Convert.ToInt32(items[0]);
                }
            }
            Console.WriteLine($"{day}");

            temperatures.Close();

        }
    }
}