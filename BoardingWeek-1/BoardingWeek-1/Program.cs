using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using static BoardingWeek_1.DataStructureQueue;
using static BoardingWeek_1.DataStructureStack;
using static BoardingWeek_1.DataStructureStack.StackUsingArray;

namespace BoardingWeek_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new graph with 5 vertices
            Graph graph = new Graph();
            // Add edges to the graph
            graph.AddEdge("0", "1");
            graph.AddEdge("0", "4");
            graph.AddEdge("1", "2");
            graph.AddEdge("1", "3");

            // Print the graph
            graph.Display();

            //MyLinkedList list = new MyLinkedList();
            //list.AddAtTail(1);
            //list.AddAtTail(2);
            //list.AddAtTail(3);
            //list.AddAtTail(4);
            //list.AddAtTail(5);
            //list.AddAtTail(6);
            //list.AddAtTail(7);
            //list.AddAtTail(8);
            //list.PrintAlternative();
            //MaxHeap h = new MaxHeap();
            //int[] ar = new int[] { 2, 3, 6, 33, 7, 2, 1, 4, 6, 7, 9, 10, 11, 12, 13 };
            //h.HeapSort(ar,ar.Length);
            //foreach(int i in ar)
            //{
            //    Console.Write(i + " ");
            //}


            //BinarySearchTree t = new BinarySearchTree();
            //t.InsertData(1);
            //t.InsertData(4);
            //t.InsertData(5);
            //t.InsertData(67);
            //t.InsertData(7);
            //t.InsertData(8);
            //t.InsertData(9);
            //t.InsertData(3);
            //t.InOrderTraversal();
            //Console.WriteLine();
            //t.PreOrderTraversal();
            //Console.WriteLine();
            //t.PostOrderTraversal();
            //Console.WriteLine();
            //int smallest = t.SmallestValue();
            //Console.WriteLine(smallest);
            //int largest = t.LargestValue();
            //Console.WriteLine(largest);

            //NewStack s = new NewStack(5);
            //s.Pushstack(4);
            //s.Pushstack(2);
            //s.Pushstack(3);
            //s.Pushstack(4);
            //s.Pushstack(1);

            //int min = s.MinStack();
            //Console.WriteLine("Small value is : " + min);
            //s.PopStack();
            //Console.WriteLine();
            //Console.WriteLine("small value is " + min);
            // remove duplicate 
            //Console.WriteLine("Hello, World!");

            //int[] duplicateArray = { 1, 1, 3, 4, 3, 4, 4, 5, 5, 3, 1, 2 };
            //int[] arr = { 11,-34,-2, 3, 2, 3, 4, 1, 6, 7, 8,2 };
            //int[] sortedArray = { 1, 2, 3, 4, 5, 6,4,4,3,3,2, 7, 8, 9, 11 };

            //Sorting_Algorithms a = new Sorting_Algorithms();

            //a.RemoveDuplicates(duplicateArray);
            //Console.WriteLine();

            //#region SelectionSort

            //a.SelectionSort(arr);

            //Console.WriteLine("SelectionSort");
            //foreach (int i in arr)
            //{
            //    Console.Write(i + " ");
            //}

            //Console.WriteLine();
            //#endregion

            //#region BubbleSort

            //Console.WriteLine("BubbleSort");
            //a.BubbleSort(arr);
            //foreach (int i in arr)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine();



            //#endregion

            //#region InsertionSort

            //Console.WriteLine("insertionSort");
            //a.InsertionSort(arr);
            //foreach (int i in arr)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine();

            //#endregion

            //#region QuickSort

            //Console.WriteLine("QuickSort");
            //a.QuickSort(arr,0,arr.Length-1);
            //foreach (int i in arr)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine();

            //#endregion

            //#region MergeSort


            //Console.WriteLine("MergeSort");
            //a.MergeSort(arr,0,arr.Length-1);
            //foreach (int i in arr)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine();

            //#endregion

            //#region Binary Search

            //int value = a.BinarySearchRecursion(sortedArray, 6, 0, sortedArray.Length-1);
            //if(value == -1)
            //{
            //    Console.WriteLine("Value is not found");
            //}
            //else
            //{
            //    Console.WriteLine("value is found");
            //}
            //#endregion

            //#region 
            //int c = a.SumArrayRecursion(sortedArray,0,sortedArray.Length-1);
            //Console.WriteLine("Sum of the arra is ;");
            //Console.Write(c);
            //Console.WriteLine();

            //#endregion

            //#region LinkedList

            //MyLinkedList obj = new MyLinkedList();

            //obj.AddAtHead(2);
            //obj.AddAtHead(3);
            //obj.AddAtHead(4);
            //obj.AddAtHead(5);
            //obj.AddAtHead(6);
            //obj.AddAtHead(7);
            //obj.SecondLargest();
            //int val = obj.Get(1);
            //Console.WriteLine("index value of 1 is : " + val);
            //obj.Display();
            //obj.ReverseLinkedList();
            ////obj.Display();

            //int middle = obj.FindmiddleElement();
            //Console.WriteLine( "Middle element is : " + middle);

            //obj.Deletevaluebefore2(5);
            //obj.Display();

            //#endregion

            //#region Stack

            //StackUsingArray s = new StackUsingArray(4);
            //s.Push(2);
            //s.Push(3);
            //s.Push(4);
            //s.Push(5);
            //s.Display();
            //Console.WriteLine();

            //StackLinkedList l = new StackLinkedList();
            //l.Push(1);
            //l.Push(2);
            //l.Push(3);
            //l.Push(4);
            //int n = l.Pop();
            //Console.Write(n);
            //Console.WriteLine();
            //l.Display();

            //#endregion

            //#region Queue

            //QueueArray q = new QueueArray(5);

            //q.Enqueue(2);
            //q.Enqueue(3);
            //q.Enqueue(4);
            //q.Enqueue(5);

            //q.Display();

            //Console.WriteLine("Removed element is :");
            //int de = q.Dequeue();
            //Console.Write(de);
            //Console.WriteLine();
            //q.Display();
            //Console.WriteLine("QueueLinkedList");

            //QueueLinkedList ql = new QueueLinkedList();
            //ql.Enqueue(2);
            //ql.Enqueue(3);
            //ql.Enqueue(4);
            //ql.Display();

            //#endregion

            //#region Hashtable

            //Console.WriteLine("Hashtable");
            //MyHashtable h = new MyHashtable(6);
            //h.LinearProbeSetValue(2, "hadhil");
            //h.LinearProbeSetValue(2, "akshay");
            //Console.WriteLine(h.GetValue(2));
            //Console.WriteLine(h.GetValue(3));

            //#endregion
        }
    }
}
