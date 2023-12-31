using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BoardingWeek_1
{
    public class Sorting_Algorithms
    {
        #region BinarySearch

        public int BinarySearch(int[] arr, int value)
        {
            int start = 0;
            int end = arr.Length;

            while (start < end)
            {
                int middle = (start + end) / 2;

                if (arr[middle] == value)
                {
                    return middle;
                }
                else if (arr[middle] > value)
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }

            return -1;
        }

        #endregion

        #region BinarySearch2

        public int BinarySearch2(int[] arr, int value)
        {
            int start = 0;
            int end = arr.Length-1;

            while (start < end)
            {
                int middle = (start + end) / 2;

                if (arr[middle] == value)
                {
                    return middle;
                }
                else if (arr[middle] > value)
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }

            return -1;
        }

        #endregion

        #region BinarySearch Recursive

        public int BinarySearchRecursive(int[] arr, int value, int start, int end)
        {
            if(start <= end)
            {
                int middle = start + (end - start) / 2; 

                if (arr[middle] == value)
                {
                    return middle;
                }
                else if (arr[middle] > value)
                {
                    return BinarySearchRecursive(arr, value, start, middle - 1);
                }
                else
                {
                    return BinarySearchRecursive(arr, value, middle + 1, end);
                }
            }

            return -1;
        }

        #endregion

        #region BinarySearchRecursion2

        public int BinarySearchRecursion(int[] arr, int val, int start, int end)
        {
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (val == arr[mid]) return mid;
                if (val > arr[mid])
                {
                    return BinarySearchRecursion(arr, val, mid + 1, end);
                }
                else
                {
                    return BinarySearchRecursion(arr, val, start, mid - 1);
                }
            }

            return -1; // Return -1 if the value is not found
        }


        #endregion

        #region Selection Sort

        public void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        #endregion

        #region BubbleSort

        public void BubbleSort(int[] arr)
        {
            for(int i = 0; i < arr.Length - 1;i++)
            {
                for(int j = 0; j < arr.Length-1; j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = temp;
                    }
                }
            }
        }

        #endregion

        #region InsertionSort

        public void InsertionSort(int[] arr)
        {
            for(int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                int j = i - 1;

                while(j >= 0 && arr[j] > temp)
                {
                    arr[j+1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }

        #endregion

        #region InsertionSort

        public void InsertionSort2(int[] arr)
        {
            for(int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                
                while(j>= 0 && arr[j] > temp)
                {
                    arr[j+1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }

        #endregion

        #region QuickSort

        public int Partition(int[] arr, int lb, int ub)
        {
            int pivot = arr[lb];
            int start = lb;
            int end = ub;

            while(start < end)
            {
                while ( arr[start] <= pivot && start < end )
                {
                    start++;
                }
                while (arr[end] > pivot)
                {
                    end--;
                }

                if(start < end)
                {
                    int temp = arr[start];
                    arr[start] = arr[end];
                    arr[end] = temp;
                }
            }
            arr[lb] = arr[end];
            arr[end] = pivot;

            return end;
        }

        public void QuickSort(int[] arr, int lb , int ub)
        {
            if(lb < ub)
            {
                int loc = Partition(arr, lb, ub);
                QuickSort(arr, lb, loc - 1);
                QuickSort(arr, loc+1, ub);
                
            }
        }

        #endregion

        #region QuickSort2

        public void QuickSort2(int[] arr, int lb, int ub)
        {
            if (lb < ub)
            {
                int loc = Partition2(arr, lb, ub);
                QuickSort2(arr, lb, loc - 1);
                QuickSort2(arr, loc + 1, ub);
            }
        }

        public int Partition2(int[] arr, int lb, int ub)
        {
            int pivot = arr[lb];
            int start = lb;
            int end = ub;

            while (start < end)
            {
                while (arr[start] <= pivot)
                {
                    start++;
                }
                while (arr[end] >= pivot) // Fix: Change the condition to arr[end] >= pivot
                {
                    end--;
                }
                if (start < end)
                {
                    int temp = arr[start];
                    arr[start] = arr[end];
                    arr[end] = temp;
                }
            }

            arr[lb] = arr[end];
            arr[end] = pivot;

            return end;
        }


        #endregion

        #region MergeSort

        public void Merge(int[] arr , int lb, int mid, int ub)
        {
            int[] B = new int[arr.Length];

            int i = lb;
            int j = mid + 1;
            int k = lb;

            while(i <= mid && j <= ub)
            {
                if (arr[i] <= arr[j])
                {
                    B[k] = arr[i];
                    i++;
                }
                else
                {
                    B[k] = arr[j];
                    j++;
                }
                k++;
            }
            if(i > mid)
            {
                while(j <= ub)
                {
                    B[k] = arr[j++];
                    k++;
                }
            }
            else
            {
                while(i<= mid)
                {
                    B[k] = arr[i++];
                    k++;
                }
            }

            for(int c = lb; c <= ub; c++)
            {
                arr[c] = B[c];
            }
        }

        public void MergeSort(int[] arr, int lb, int ub)
        {
            if(lb < ub)
            {
                int mid = ( lb + ub ) / 2;

                MergeSort(arr, lb, mid);
                MergeSort(arr, mid+1, ub);
                Merge(arr, lb, mid, ub);
            }
        }

        #endregion

        #region MergeSort2

        public void MergeSort2(int[] newArr, int lb, int ub)
        {
            if (lb < ub)
            {
                int mid = (ub + lb) / 2;
                MergeSort2(newArr, lb, mid);
                MergeSort2(newArr, mid + 1, ub);
                Merge2(newArr, lb, mid, ub);
            }
        }

        public void Merge2(int[] newArr, int lb, int mid, int ub)
        {
            int[] arr = new int[newArr.Length];

            int i = lb;
            int j = mid + 1;
            int k = lb;

            while (i <= mid && j <= ub)
            {
                if (newArr[i] < newArr[j]) // Fix: Compare elements in newArr, not arr
                {
                    arr[k] = newArr[i];
                    i++;
                }
                else
                {
                    arr[k] = newArr[j];
                    j++;
                }

                k++;
            }

            if (i > mid)
            {
                while (j <= ub)
                {
                    arr[k] = newArr[j];
                    k++;
                    j++;
                }
            }
            else
            {
                while (i <= mid)
                {
                    arr[k] = newArr[i];
                    k++;
                    i++;
                }
            }

            for (int m = lb; m <= ub; m++) // Fix: Copy back elements only in the specified range
            {
                newArr[m] = arr[m];
            }
        }


        #endregion

        #region  Sum of Array Recursion

        public int SumArrayRecursion(int[] arr, int start, int end)
        {
            if(start > end)
            {
                return 0;
            }
            else
            {
                return arr[start] + SumArrayRecursion(arr, start + 1 , end);
            }
        }

        #endregion

        #region Fibonacci Series Recursion

        public int FibonacciRecursion(int num)
        {
            if(num == 1)
            {
                return 0;
            }
            if(num == 2)
            {
                return 1;
            }

            return FibonacciRecursion(num - 1) + FibonacciRecursion(num - 2);
        }

        #endregion

        #region Factorial Number

        public int FactorialRecursion(int num)
        {
            if(num <= 1)
            {
                return 1;
            }

            return num * FactorialRecursion(num - 1);
        }

        #endregion

        #region RemoveDuplicates

        public void RemoveDuplicates(int[] arr)
        {
            int l = arr.Length;
            for(int i = 0; i < l-1; i++)
            {
                for(int j= i+1; j < l; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        for(int k = j; k < l-1; k++)
                        {
                            arr[k] = arr[k + 1];
                        }
                        l--;
                        j--;
                        
                        
                    }
                }
            }

            for(int m = 0; m < l; m++)
            {
                Console.Write(arr[m] + "\t");
            }
        }

        #endregion

    }
}
