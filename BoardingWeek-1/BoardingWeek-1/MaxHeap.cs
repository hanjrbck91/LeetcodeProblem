using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardingWeek_1
{
    public class MaxHeap
    {
        List<int> maxHeap = new List<int>();

        #region Add Value

        public void AddValueHeap(int value)
        {
            maxHeap.Add(value);
            int currentIndex = maxHeap.Count - 1;
            while (currentIndex > 0)
            {
                int parentIndex = (currentIndex - 1) / 2;
                if (maxHeap[parentIndex] < maxHeap[currentIndex])
                {
                    int temp = maxHeap[parentIndex];
                    maxHeap[parentIndex] = maxHeap[currentIndex];
                    maxHeap[currentIndex] = temp;
                }
                else
                {
                    break;
                }
                currentIndex = parentIndex;
            }
        }

        #endregion

        #region DisplayHeap

        public void displayHeap()
        {
            foreach (int value in maxHeap)
            {
                Console.WriteLine(value + "\t");
            }
        }

        #endregion

        #region RemoveValue

        public int RemoveValue()
        {
            if (maxHeap.Count == 0)
            {
                throw new InvalidOperationException("Heap is Empty");
            }

            int data = maxHeap[0];
            maxHeap[0] = maxHeap[maxHeap.Count - 1];
            maxHeap.RemoveAt(maxHeap.Count - 1);
            int currentIndex = 0;
            while (currentIndex < maxHeap.Count)
            {
                int leftChildIndex = 2 * currentIndex + 1;
                int rightChildIndex = 2 * currentIndex + 2;
                int maxChildValueIndex = 0;
                if (leftChildIndex < maxHeap.Count && maxHeap[leftChildIndex] > maxHeap[currentIndex])
                {
                    maxChildValueIndex = leftChildIndex;
                }
                if (rightChildIndex < maxHeap.Count && maxHeap[rightChildIndex] > maxHeap[currentIndex])
                {
                    maxChildValueIndex = rightChildIndex;
                }
                if (currentIndex != 0)
                {
                    int temp = maxHeap[currentIndex];
                    maxHeap[currentIndex] = maxHeap[maxChildValueIndex];
                    maxHeap[maxChildValueIndex] = temp;

                    // updation
                    currentIndex = maxChildValueIndex;
                }
                else
                {
                    break;
                }
            }
            return data;
        }

        #endregion

        #region Heapify

        public void MaxHeapify(int[] arr, int arrLength, int i)
        {
            int maxValue = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < arrLength && arr[maxValue] < arr[left])
            {
                maxValue = left;
            }

            if (right < arrLength && arr[maxValue] < arr[right])
            {
                maxValue = right;
            }

            if (maxValue != i)
            {
                int temp = arr[i];
                arr[i] = arr[maxValue];
                arr[maxValue] = temp;
                MaxHeapify(arr, arrLength, maxValue);
            }
        }

        #endregion

        #region HeapSort

        public void HeapSort(int[] arr, int arrLength)
        {
            for(int i = (arrLength/2) -1; i >=0 ; i--)
            {
                MaxHeapify(arr, arrLength, i);          // Create Heap
            }
            for(int j = arr.Length-1; j > 0 ; j--)
            {
                int temp = arr[0];
                arr[0] = arr[j];              // Delete One by one
                arr[j] = temp;
                MaxHeapify(arr, j, 0);
            }
        }

        #endregion

        #region IsHeap

        public bool IsHeap(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n / 2 - 1; i++)
            {
                int left = 2 * i + 1;
                int right = 2 * i + 2;

                if (left < n && arr[i] < arr[left] && right < n && arr[i] < arr[right])
                {
                    // The current node is greater than both its left and right children
                }
                else
                {
                    // The array does not satisfy the heap property
                    Console.WriteLine("Given array is not a Heap");
                    return false;
                }
            }

            return true;
        }


        #endregion
         
    }
}
