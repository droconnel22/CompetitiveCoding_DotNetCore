namespace Binary.Review1.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            int a = 25;
            int b = 7;

            var result = a & b;

            Console.WriteLine($"{Convert.ToString(a, 2).PadLeft(8, '0')}");
            Console.WriteLine($"{Convert.ToString(b, 2).PadLeft(8, '0')}");
            Console.WriteLine("------");
            Console.WriteLine($"{Convert.ToString(result, 2).PadLeft(8, '0')}");

            Console.WriteLine();
            int c = 1;
            int d = 2;

            string stringBinaryC = Convert.ToString(c, 2).PadLeft(8, '0');
            string stringBinaryD = Convert.ToString(d, 2).PadLeft(8, '0');

            var e = c + d;

            Console.WriteLine(e);
            byte[] byteArray = BitConverter.GetBytes(e);



            Console.WriteLine($"{stringBinaryC}");
            Console.WriteLine($"{stringBinaryD}");
            Console.WriteLine("------");


            // Bitwise operatoers
            // AND & (Both)
            // OR | (Either)
            // Xor ^ (Exclusive or, different)
            // Not ~ (Invert)

            // Bitwise Shifting
            // Left <<
            // Right >>

            // Usage
            // Toggling boolean
            // Enum flags
            // masking

            long f = 190327840912734098;
            byte[] byteArray64 = BitConverter.GetBytes(f);
            string stringBinaryF = Convert.ToString(f, 2).PadLeft(8, '0');
            string resultb = string.Empty;
            foreach (byte bb in byteArray64)
            {
                resultb += Convert.ToString(bb, 2);
            }
            Console.WriteLine($"built in {stringBinaryF} \n other {resultb}");
            Console.WriteLine("-------------");

            string testNum = "12345";           
           // byte[] bytes = testNum.Select(c1 => (byte)(c1)).ToArray();
            byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(testNum));
            string resultM = string.Empty;
            foreach (byte bb in bytes)
            {
                resultM += Convert.ToString(bb, 2);
            }

             string stringBinaryM = Convert.ToString(12345, 2).PadLeft(8, '0');
            Console.WriteLine($"scenario 2: built in {stringBinaryM} \n other {resultM}");

        }
              
    }
}
