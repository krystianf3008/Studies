using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortowanie
{
    public class SelectionSort
    {
        public void Sort(List<int> list)
        {
            int n = list.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (list[j] < list[min_idx])
                        min_idx = j;

                int temp = list[min_idx];
                list[min_idx] = list[i];
                list[i] = temp;
            }
        }
    }
}
