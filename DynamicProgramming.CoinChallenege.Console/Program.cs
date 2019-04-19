namespace DynamicProgramming.CoinChallenege.Console
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int[] array = new int[] { 1, 2, 3 };
            int expected = 4;
            int actual = CoinChange.MakeChange(n, array);
            Console.WriteLine($"Expected {expected}; Actual {actual}");

            int n2 = 10;
            int[] coins2 = new int[] { 2, 5, 3, 6 };
            int actual2 = CoinChange.MakeChange(n2, coins2);
            int expected2 = 5;
            Console.WriteLine($"Expected {expected2}; Actual {actual2}");

        }
    }

    internal static class CoinChange
    {
        //how many ways can we make the change?
        public static int MakeChange(int n, int[] coins, int currentCoin = 0, IDictionary<int,int> memo = null)
        {
            if (memo == null) memo = new Dictionary<int, int>();
            // ran out of money or coins
            if (n < 0 || currentCoin == coins.Length) return 0;
            // n is zero perfect!
            if (n == 0) return 1;

            if (memo.ContainsKey(n)) return memo[n];

            // sum of going to next coin or subtracting this current coin.
            memo[n] = MakeChange(n - coins[currentCoin], coins, currentCoin) + MakeChange(n, coins, currentCoin + 1);
            return memo[n];
        }
    }
}
