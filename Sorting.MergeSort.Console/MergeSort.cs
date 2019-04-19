namespace Sorting.MergeSort.Console
{
    using System;

    public class MergeSort<T>
        where T : IComparable<T>
    {
        [ThreadStatic]
        private static MergeSort<T> instance;

        private MergeSort()
        {

        }

        public static MergeSort<T> Get()
        {
            if (instance == null)
                instance = new MergeSort<T>();
            return instance;
        }

        public T[] Sort(T[] array)
        {
            if (array.Length < 2) return array;
            int midpoint = array.Length / 2;
            T[] leftHalf = Sort(SplitArray(array, 0, midpoint));
            T[] rightHalf = Sort(SplitArray(array, midpoint, array.Length));
            return merge(leftHalf, rightHalf);
        }     

        private T[] SplitArray(T[] array, int left, int right)
        {
            int resultSize = right - left;
            int resultIndex = 0;
            T[] resultArray = new T[resultSize];
            for(int i = left; i <right; i++)
            {
                resultArray[resultIndex] = array[i];
                resultIndex++;
            }
            return resultArray;
        }

        private T[] merge(T[] leftArray, T[] rightArray)
        {
            int resultSize = leftArray.Length + rightArray.Length;
            T[] resultArray = new T[resultSize];
            int resultIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;

            while(resultIndex < resultSize)
            {
                if(leftIndex == leftArray.Length && rightIndex < rightArray.Length)
                {
                    resultArray[resultIndex] = rightArray[rightIndex];
                    rightIndex++;
                }
                else if(rightIndex == rightArray.Length && leftIndex < leftArray.Length)
                {
                    resultArray[resultIndex] = leftArray[leftIndex];
                    leftIndex++;
                }
                else if(leftArray[leftIndex].CompareTo(rightArray[rightIndex]) <= 0)
                {
                    resultArray[resultIndex] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    resultArray[resultIndex] = rightArray[rightIndex];
                    rightIndex++;
                }
                resultIndex++;
            }

            return resultArray;
        }
    }
}
