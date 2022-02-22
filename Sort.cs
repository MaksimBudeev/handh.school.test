using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace handh.school.test
{
    public class Sort<T> where T : IComparable<T>
    {
        public delegate bool Compare(T a, T b);

        internal static bool Min(T a, T b)
        {
            if (a.CompareTo(b) <= 0)
            {
                return true;
            }

            return false;
        }

        internal static bool Max(T a, T b)
        {
            if (b.CompareTo(a) < 0)
            {
                return true;
            }

            return false;
        }

        private static void Heapify(T[] arr, int n, int i, Compare comp)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && comp(arr[left], arr[largest]))
            {
                largest = left;
            }
 
            if (right < n && comp(arr[right], arr[largest]))
            {
                largest = right;
            }
             
            if (largest != i)
            {
                T swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                Heapify(arr, n, largest, comp);
            }
        }

        internal static void HeapSort(T[] arr, Sort<T>.Compare comp)
        {
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, arr.Length, i, comp);
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                T temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                Heapify(arr, i, 0, comp);
            }
        }
    }
}
