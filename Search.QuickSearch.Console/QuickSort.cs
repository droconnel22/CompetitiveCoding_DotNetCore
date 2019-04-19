namespace Search.QuickSearch.Console
{
    using System;

    public class QuickSort<T>
        where T : IComparable<T>
    {
        [ThreadStatic]
        private static QuickSort<T> instance;

        private static Random random = new Random();

        private QuickSort()
        {

        }

        public static QuickSort<T> Get()
        {
            if (instance == null)
                instance = new QuickSort<T>();
            return instance;
        }

        public void Sort(T[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            sort(array, 0, array.Length - 1);
        }

        private void sort(T[] array, int left, int right)
        {
            if(left < right)
            {
                int pivotHeuristicIndex = heurisitic(left, right);
                int pivotIndex = partition(array, left, right, pivotHeuristicIndex);
                sort(array, left, pivotIndex-1);
                sort(array, pivotIndex + 1, right);
            }
        }

        private void swap(T[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private int heurisitic(int low, int high) => random.Next(low, high);

        private int partition(T[] array, int left, int right, int heuristicIndex)
        {
            T pivotValue = array[heuristicIndex];
            swap(array, heuristicIndex, right);
            int i = left;
            int j = right;
            bool inProgress = true;
            while(inProgress)
            {
                while (i < j && array[i].CompareTo(pivotValue) <= 0) i++;
                while (i < j && array[j].CompareTo(pivotValue) > 0) j--;
                if(i < j)
                {
                    swap(array, i, j);                   
                }
                else
                {
                    inProgress = false;
                }
            }

            int pivotIndex = i;
            swap(array, right, pivotIndex);
            return pivotIndex;
        }
    }
}