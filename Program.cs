using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace handh.school.test
{
    public class Program
    {
        public static int[][] TestTask(int n)
        {
            int[][] result;
            try
            {
                result = new int[n][];
                HashSet<int> sizeOfArrSet = new HashSet<int>();

                int newSize;
                Random r = new Random();

                int i;

                for (i = 0; i < n; i++)
                {
                    newSize = r.Next(1, n * 2);

                    if (sizeOfArrSet.Contains(newSize))
                    {
                        i--;
                        continue;
                    }

                    sizeOfArrSet.Add(newSize);

                    result[i] = new int[newSize];
                }

                for (i = 0; i < n; i++)
                {
                    for (int j = 0; j < result[i].Length; j++)
                    {
                        result[i][j] = r.Next(int.MinValue, int.MaxValue);
                    }
                }

                Sort<int>.Compare min, max;

                min = Sort<int>.Min;
                max = Sort<int>.Max;

                for (i = 0; i < result.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        Sort<int>.HeapSort(result[i], min);
                    }
                    else
                    {
                        Sort<int>.HeapSort(result[i], max);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an exception: {ex.Message}");
                return null;
            }
        }
        public static void Main(string[] args)
        {
            int[][] arrOfArr;
            int arrOfArrSize = Convert.ToInt32(args[0]);
           
            arrOfArr = TestTask(arrOfArrSize);

            if(arrOfArr != null)
            {
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("arrOfArr is null.");
            }
        }
    }
}