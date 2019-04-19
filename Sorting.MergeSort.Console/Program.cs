namespace Sorting.MergeSort.Console
{
    using System;
    using System.Linq;

    class MainClass
    {
        private static Random Random = new Random();

        public static void Main(string[] args)
        {

            int n = 25;
            int[] array = Enumerable.Repeat(0, n).Select(i => Random.Next(0, n * 10)).ToArray();
            array.Print(i => Console.Write(i + " "), Console.WriteLine);
            var sortedArray = array.Sort();
            sortedArray.Print(i => Console.Write(i + " "), Console.WriteLine);
            Console.ReadLine();
        }
    }

    public static class ArrayExtensions
    {
        public static void Print<T>(this T[] array, Action<T> onItem, Action afterItem = null)
        {
            var itemIterator = array.GetEnumerator();
            while (itemIterator.MoveNext())
            {
                onItem((T)itemIterator.Current);
            }

            afterItem?.Invoke();
        }

        public static T[] Sort<T>(this T[] array) where T : IComparable<T> => MergeSort<T>.Get().Sort(array);

    }
}
