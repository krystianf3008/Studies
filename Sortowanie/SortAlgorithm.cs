using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortowanie
{
    public class SortAlgorithm
    {
        public string Name { get; }
        private Action<List<int>> SortAction { get; }

        public SortAlgorithm(string name, Action<List<int>> sortAction)
        {
            Name = name;
            SortAction = sortAction;
        }

        public void Sort(List<int> data)
        {
            SortAction(data);
        }
    }
}
