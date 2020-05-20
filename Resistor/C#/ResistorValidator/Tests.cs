using System;

namespace ResistorValidator
{
    public class TestData
    {
        public string[] stripes;
        public double measuredOhms;
        public bool valid;

        public TestData(string[] stripes, double measuredOhms, bool valid)
        {
            this.stripes = stripes;
            this.measuredOhms = measuredOhms;
            this.valid = valid;
        }
    }

    public class Tests
    {
        static TestData[] _testCases =
        {
            new TestData(new string[] { "brown", "black", "red", "gold" }, 1017, true),
            new TestData(new string[] { "yellow", "violet", "orange", "gold" }, 44650, true),
            new TestData(new string[] { "green", "red", "gold", "silver" }, 4.5, false),
            new TestData(new string[] { "white", "violet", "black", "none" }, 78, true),
            new TestData(new string[] { "orange", "orange", "black", "brown", "brown" }, 3333, true),
            new TestData(new string[] { "orange", "orange", "black", "brown", "brown" }, 3334, false),
            new TestData(new string[] { "brown", "green", "gray", "silver", "red" }, 1.6, true),
            new TestData(new string[] { "brown", "green", "gray", "silver", "red" }, 1.8, false),
            new TestData(new string[] { "blue", "gray", "yellow", "none" }, 544000, true),
            new TestData(new string[] { "blue", "gray", "yellow", "none" }, 543999, false),
        };

        public void RunTests(Validator validator)
        {
            foreach (TestData test in _testCases)
            {
                bool inRange = validator.IsInRange(test.stripes, test.measuredOhms);
                if (inRange != test.valid)
                {
                    Console.WriteLine($"** FAILED: {inRange} {String.Join(',', test.stripes)}");
                }
            }
        }
    }
}
