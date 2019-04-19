namespace DynamicProgramming.Fibonacci.Console
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
           int N = 8;
            long NN = 1000;
            BigInteger NNN = 10000;
           
            int result = Fibonacci.NaiveFibo(N);
            long result2 = Fibonacci.MemoFib(NN);
            BigInteger result3 = Fibonacci.BigMemoFib(NNN);
            Console.WriteLine($"Naive F({N}) = {result}");
            Console.WriteLine($"Memo F({NN}) = {result2}");
            Console.WriteLine($"Memo F({NNN}) = {result3}");
                      
        }
    }

    public static class Fibonacci
    {
        public static int NaiveFibo(int n)
        {
            if(n < 2) return 1;

            return NaiveFibo(n - 1) + NaiveFibo(n - 2);
        }

        public static long MemoFib(long n, IDictionary<long, long> memo = null)
        {
            if (memo == null) memo = new Dictionary<long, long>();
            if (memo.ContainsKey(n)) return memo[n];
            if (n < 2) return 1;
            memo[n] = MemoFib(n - 1, memo) + MemoFib(n - 2, memo);
            return memo[n];
        }

        public static BigInteger BigMemoFib(BigInteger n, IDictionary<BigInteger, BigInteger> memo = null)
        {
            if (memo == null) memo = new Dictionary<BigInteger, BigInteger>();
            if (memo.ContainsKey(n)) return memo[n];
            if (n < 2) return 1;
            memo[n] = BigMemoFib(n - 1, memo) + BigMemoFib(n - 2, memo);
            return memo[n];
        }      

        public static byte[] convertToBytes(string number)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(number);
            return bytes;
        }

        public  static string convertToString(byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes);
        }

        public static string IntToBinarySTring(int number)
        {
            const int mask = 1;
            var binary = string.Empty;
            while(number > 0)
            {
                binary = (number & mask) + binary;
                number = number >> 1;
            }

            return binary;
        }

        public static string GetBinaryString(string number )
        {
            string result = string.Empty;
            /*
            foreach(char c in number.ToCharArray())
            {
                int r;
                if(!int.TryParse(c.ToString(), out r))
                {
                    throw new Exception("Unable to parse " + c.ToString());
                }

                result += Convert.ToString(r, 2);
            }
            Console.WriteLine(result);
            */
            return Convert.ToString(Convert.ToInt64(number), 2);
        }

       

        internal struct BigNumberBuffer
        {
            public StringBuilder digits;
            public int precision;
            public int scale;
            public bool sign;  // negative sign exists

            public static BigNumberBuffer Create()
            {
                BigNumberBuffer number = new BigNumberBuffer();
                number.digits = new StringBuilder();
                return number;
            }
        }

    }
}
