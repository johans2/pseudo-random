using System;
using System.Collections.Generic;

namespace PseudoRandom
{
    public static class RandomGenerator
    {
        public static int[] GeneratePRandomSerie(int seedX, int seedY, int maxValue) 
        {
            List<int> returnValues = new List<int>();
            int combinedSeed = CombineSeeds(seedX, seedY);
            Random random = new Random(combinedSeed);

            for (int i = 0; i < 10; i++)
			{
			    returnValues.Add(random.Next(0,maxValue));
			}

            return returnValues.ToArray();
        }

        public static int CombineSeeds(int seedX, int seedY)
        {
            //a^(x) + b^(y) - z
            return (((int)Math.Pow(seedX, 3) + (int)Math.Pow(seedY, 5)) % int.MaxValue) - 7;
        }
    }
}
