using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortowanie
{
    public class QuickSortLast
    {
        public void Sort(List<int> data)
        {
            QuickSort(data, 0, data.Count - 1);
        }

        private void QuickSort(List<int> data, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(data, low, high);
                QuickSort(data, low, pivotIndex - 1);
                QuickSort(data, pivotIndex + 1, high);
            }
        }

        private int Partition(List<int> data, int low, int high)
        {
            int pivotIndex = high;
            int pivotValue = data[pivotIndex];
            int smallerIndex = low - 1;

            for (int i = low; i < high; i++)
            {
                if (data[i] < pivotValue)
                {
                    smallerIndex++;
                    Swap(data, smallerIndex, i);
                }
            }
            Swap(data, smallerIndex + 1, pivotIndex);

            return smallerIndex + 1;
        }

        private void Swap(List<int> data, int i, int j)
        {
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }

    public class QuickSortMiddle
    {
        public void Sort(List<int> data)
        {
            QuickSort(data, 0, data.Count - 1);
        }

        private void QuickSort(List<int> data, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(data, low, high);
                QuickSort(data, low, pivotIndex - 1);
                QuickSort(data, pivotIndex + 1, high);
            }
        }

        private int Partition(List<int> data, int low, int high)
        {
            int pivotIndex = low + (high - low) / 2;
            int pivotValue = data[pivotIndex];
            int smallerIndex = low - 1;

            for (int i = low; i <= high; i++)
            {
                if (data[i] < pivotValue)
                {
                    smallerIndex++;
                    Swap(data, smallerIndex, i);
                }
            }
            Swap(data, smallerIndex + 1, pivotIndex);

            return smallerIndex + 1;
        }

        private void Swap(List<int> data, int i, int j)
        {
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }

    public class QuickSortRandom
    {
        Random rand;

        public QuickSortRandom()
        {
            rand = new Random();
        }

        public void Sort(List<int> data)
        {
            QuickSort(data, 0, data.Count - 1);
        }

        private void QuickSort(List<int> data, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(data, low, high);
                QuickSort(data, low, pivotIndex - 1);
                QuickSort(data, pivotIndex + 1, high);
            }
        }

        private int Partition(List<int> data, int low, int high)
        {
            int pivotIndex = rand.Next(low, high + 1);
            int pivotValue = data[pivotIndex];
            int smallerIndex = low - 1;

            for (int i = low; i <= high; i++)
            {
                if (data[i] < pivotValue)
                {
                    smallerIndex++;
                    Swap(data, smallerIndex, i);
                }
            }
            Swap(data, smallerIndex + 1, pivotIndex);

            return smallerIndex + 1;
        }

        private void Swap(List<int> data, int i, int j)
        {
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }




    }




    public class QuickSortRecursive
    {
        public void Sort(List<int> data)
        {
            quickSortRecursive(data, 0, data.Count - 1);
        }

        private void quickSortRecursive(List<int> data, int low, int high)
        {
            if (low < high)
            {
                int pi = partition(data, low, high);
                quickSortRecursive(data, low, pi - 1);
                quickSortRecursive(data, pi + 1, high);
            }
        }

        private int partition(List<int> data, int low, int high)
        {
            int pivot = data[high];
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                if (data[j] < pivot)
                {
                    i++;
                    int temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                }
            }
            int temp1 = data[i + 1];
            data[i + 1] = data[high];
            data[high] = temp1;

            return (i + 1);
        }
    }

    public class QuickSortIterative
    {
        public void Sort(List<int> data)
        {
            quickSortIterative(data, 0, data.Count - 1);
        }

        private void quickSortIterative(List<int> data, int low, int high)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(low);
            stack.Push(high);

            while (stack.Count > 0)
            {
                high = stack.Pop();
                low = stack.Pop();

                int pivot = partition(data, low, high);

                if (pivot - 1 > low)
                {
                    stack.Push(low);
                    stack.Push(pivot - 1);
                }

                if (pivot + 1 < high)
                {
                    stack.Push(pivot + 1);
                    stack.Push(high);
                }
            }
        }

        private int partition(List<int> data, int low, int high)
        {
            int pivot = data[high];
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                if (data[j] < pivot)
                {
                    i++;
                    int temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                }
            }
            int temp1 = data[i + 1];
            data[i + 1] = data[high];
            data[high] = temp1;

            return (i + 1);
        }
    }
}
