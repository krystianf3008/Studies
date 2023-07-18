using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Sortowanie
{
    internal class Program
    {
        

        public static void Main(string[] args)
            {
                DataGenerator generator = new DataGenerator();
                InsertionSort insertionSort = new InsertionSort();
                SelectionSort selectionSort = new SelectionSort();
                HeapSort heapSort = new HeapSort();
                CocktailSort cocktailSort = new CocktailSort();
                


            List<SortAlgorithm> sortAlgorithms = new List<SortAlgorithm>()
        {
            new SortAlgorithm("InsertionSort", data => insertionSort.Sort(data)),
            new SortAlgorithm("SelectionSort", data => selectionSort.Sort(data)),
            new SortAlgorithm("HeapSort", data => heapSort.Sort(data)),
            new SortAlgorithm("CocktailSort", data => cocktailSort.Sort(data)),
        };
            



            
            
            List<string> dataTypes = new List<string>() { "Random", "Increasing", "Decreasing", "Constant", "VShaped" };
            
            
                // Create files per algorithm, with different data types
                foreach (var sortAlgorithm in sortAlgorithms)
                {
                    using StreamWriter file = new StreamWriter($"C:\\Users\\Krystian\\Desktop\\Sortowania\\{sortAlgorithm.Name}_Results.csv");
                    file.WriteLine("Size,Algorithm,Data,Time");

                    for (int size = 10000; size <= 100000; size += 10000)
                    {
                        foreach (var dataType in dataTypes)
                        {
                            List<int> data = new List<int>(generator.Generate(dataType, size));
                            Stopwatch stopwatch = Stopwatch.StartNew();
                            sortAlgorithm.Sort(data);
                            stopwatch.Stop();

                            file.WriteLine($"{size},{sortAlgorithm.Name},{dataType},{stopwatch.Elapsed.TotalSeconds.ToString("F10").Replace(',', '.')}");
                        }
                    }
                    Console.WriteLine($"Ended for {sortAlgorithm.Name}");
                }
            

                // Create files per data type, with different algorithms
                
                foreach (var dataType in dataTypes)
                {
                    using StreamWriter file = new StreamWriter($"C:\\Users\\Krystian\\Desktop\\Sortowania\\{dataType}_Results.csv");
                    file.WriteLine("Size,Algorithm,Data,Time");

                    for (int size = 10000; size <= 100000; size += 10000)
                    {
                        foreach (var sortAlgorithm in sortAlgorithms)
                        {
                            List<int> data = new List<int>(generator.Generate(dataType, size));
                            Stopwatch stopwatch = Stopwatch.StartNew();
                            sortAlgorithm.Sort(data);
                            stopwatch.Stop();

                            file.WriteLine($"{size},{sortAlgorithm.Name},{dataType},{stopwatch.Elapsed.TotalSeconds.ToString("F10").Replace(',', '.')}");
                        }
                    }
                    Console.WriteLine($"Ended for {dataType}");
                }
          
            


            Thread TesterThread = new Thread(QuickSortTest, 8 * 1024 * 1024); // utworzenie wątku
            TesterThread.Start(); // uruchomienie wątku
            TesterThread.Join(); // oczekiwanie na zakończenie wątku

            








        }





        public static void QuickSortTest()
        {
            DataGenerator generator = new DataGenerator();

            QuickSortRecursive quickSortRecursive = new QuickSortRecursive();
            QuickSortIterative quickSortIterative = new QuickSortIterative();
            List<SortAlgorithm> quickSortImplementations = new List<SortAlgorithm>()

    {
        new SortAlgorithm("QuickSortRecursive", data => quickSortRecursive.Sort(data)),
        new SortAlgorithm("QuickSortIterative", data => quickSortIterative.Sort(data)),
    };
            QuickSortLast quickSortLast = new QuickSortLast();
            QuickSortMiddle quickSortMiddle = new QuickSortMiddle();
            QuickSortRandom quickSortRandom = new QuickSortRandom();
            List<SortAlgorithm> quickSortAlgorithms = new List<SortAlgorithm>()
    {
        new SortAlgorithm("QuickSortLast", data => quickSortLast.Sort(data)),
        new SortAlgorithm("QuickSortMiddle", data => quickSortMiddle.Sort(data)),
        new SortAlgorithm("QuickSortRandom", data => quickSortRandom.Sort(data)),
    };  

            string dataTypeQ = "AShaped";
            
            using (StreamWriter file = new StreamWriter($"C:\\Users\\Krystian\\Desktop\\Sortowania\\QuickSortLastMiddleRandom_Results.csv"))
            {
                file.WriteLine("Size,Algorithm,Data,Time");
                foreach (var quickSortAlgorithm in quickSortAlgorithms)
                {

                    

                    for (int size = 10000; size <= 100000; size += 10000)
                    {
                        List<int> data = new List<int>(generator.Generate(dataTypeQ, size));
                        Stopwatch stopwatch = Stopwatch.StartNew();
                        quickSortAlgorithm.Sort(data);
                        stopwatch.Stop();

                        file.WriteLine($"{size},{quickSortAlgorithm.Name},{dataTypeQ},{stopwatch.Elapsed.TotalSeconds.ToString("F10").Replace(',', '.')}");
                    }

                    Console.WriteLine($"Ended for {quickSortAlgorithm.Name}");
                }
            }
            
            string dataTypeQI = "Random";
            using (StreamWriter file = new StreamWriter($"C:\\Users\\Krystian\\Desktop\\Sortowania\\QuickSortComparsion_Results.csv"))
            { 
            file.WriteLine("Size,Algorithm,Data,Time");

                foreach (var quickSortImplementation in quickSortImplementations)
                {



                    for (int size = 10000; size <= 100000; size += 10000)
                    {
                        List<int> data = new List<int>(generator.Generate(dataTypeQI, size));
                        Stopwatch stopwatch = Stopwatch.StartNew();
                        quickSortImplementation.Sort(data);
                        stopwatch.Stop();

                        file.WriteLine($"{size},{quickSortImplementation.Name},{dataTypeQI},{stopwatch.Elapsed.TotalSeconds.ToString("F10").Replace(',', '.')}");
                    }
                };
                Console.WriteLine($"Ended for Comparsion");
            }
            
            






        }




    }
        }
    

    




    
