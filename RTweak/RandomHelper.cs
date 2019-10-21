using System;
using System.Collections.Generic;

namespace RTweak
{
    public static class RandomHelper
    {
        public static double GetDoubleInRange(this Random random, double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public static bool GetBoolWithChance(this Random random, double chance)
        {
            return random.NextDouble() <= chance;
        }

        public static string GetStringFromList(this Random random, IList<string> nameList)
        {
            return nameList[random.Next(0, nameList.Count)];
        }
    }
}
