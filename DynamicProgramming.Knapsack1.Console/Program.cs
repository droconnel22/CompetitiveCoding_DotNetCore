namespace DynamicProgramming.Knapsack1.Console
{

    using System;

    /*
     * 
     * 0-1 Knapsack Problem
     * 
     * Given weights and values of n items, put these items in a knapsack of 
     * capacity W to get the maximum total value in the knapsack. 
     * 
     * In other words, given two integer arrays val[0..n-1] and wt[0..n-1] 
     * which represent values and weights associated with n items respectively. 
     * 
     *  Also given an integer W which represents knapsack capacity, 
     * find out the maximum value subset of val[] such that sum of the 
     * weights of this subset is smaller than or equal to W. 
     * 
     * You cannot break an item, either pick the complete item, 
     * or don’t pick it (0-1 property).
     */   

    class Program
    {
        static void Main(string[] args)
        {
            var values = new int[] { 60, 100, 120 };
            var weights = new int[] { 10, 20, 30 };
            int capacityW = 50;
            int expectedSolution = 220;
            int actualSolution = Knapsack.GetMax(values, weights, capacityW);
            Console.WriteLine($"Actual {actualSolution}; Expected {expectedSolution}");
        }
    }

    internal static class Knapsack
    {
        public static int GetMax(int[] values, int[] weights, int capacity, int currentValue = 0, int currentIndex = 0)
        {
           
            if (capacity < 0) return 0;
            if (capacity == 0) return currentValue;
            if (currentIndex == values.Length) return 0;
            Console.WriteLine($"Remaining Capacity:{capacity} Current Value:{currentValue} Weight:{weights[currentIndex]} Value:{values[currentIndex]}");

            return Math.Max(currentValue, Math.Max(
                    // Dont pick the item - skip
                    GetMax(values, weights, capacity, 0,  currentIndex+1),
                    // Apply the item, decrement the capacity 
                    GetMax(values, weights, capacity-weights[currentIndex], currentValue + values[currentIndex], currentIndex+1))
                );
        }
    }
}
