using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortowanie
{
    public class DataGenerator
    {
        private Random rand;

        public DataGenerator()
        {
            rand = new Random();
        }

        public List<int> GenerateRandom(int n)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                list.Add(rand.Next(n));
            }
            return list;
        }
        public List<int> Generate(string type, int size)
        {
            switch (type)
            {
                case "Random":
                    return GenerateRandom(size);
                case "Increasing":
                    return GenerateIncreasing(size);
                case "Decreasing":
                    return GenerateDecreasing(size);
                case "Constant":
                    return GenerateConstant(size);
                case "VShaped":
                    return GenerateVShaped(size);
                case "AShaped":
                    return GenerateAShaped(size);
                default: throw new Exception();
            }
        }
    
        public List<int> GenerateIncreasing(int n)
        {
            return Enumerable.Range(0, n).ToList();
        }

        public List<int> GenerateDecreasing(int n)
        {
            return Enumerable.Range(0, n).Reverse().ToList();
        }

        public List<int> GenerateConstant(int n)
        {
            return Enumerable.Repeat(rand.Next(n), n).ToList();
        }

        public List<int> GenerateVShaped(int n)
        {
            List<int> list = GenerateDecreasing(n / 2);
            list.AddRange(GenerateIncreasing(n / 2));
            return list;
        }
        public List<int> GenerateAShaped(int n)
        {
            List<int> list = GenerateDecreasing(n / 2);
            list.AddRange(GenerateIncreasing(n - n / 2));
            return list;
        }
    }
}