using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardingWeek_1
{
    public class MyLinkedList
    {
        public class Node
        {
            public int Value;
            public Node Next;
          //public Node Prev;

            public Node(int val)
            {
                Value = val;
            }
        }

        private Node head;
      //private Node tail;
        private int size;

        public MyLinkedList()
        {
            head = null;
            size = 0;
        }

        #region Get
        public int Get(int index)
        {
            if (index < 0 || index >= size)
            {
                return -1;
            }
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }
        #endregion

        #region AddAtHead
        public void AddAtHead(int val)
        {
            Node newNode = new Node(val);
            newNode.Next = head;
            head = newNode;
            size++;
        }
        #endregion

        #region AddAtTail
        public void AddAtTail(int val)
        {
            Node newNode = new Node(val);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }

            size++;
        }
        #endregion

        #region AddAtIndex
        public void AddAtIndex(int index, int val)
        {
            if (index < 0 || index > size)
            {
                return;
            }
            if (index == 0)
            {
                AddAtHead(val);
            }
            else
            {
                Node newNode = new Node(val);
                Node current = head;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                newNode.Next = current.Next;
                current.Next = newNode;
                size++;
            }
        }

        #endregion

        #region DeleteAtIndex
        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= size)
            {
                return;
            }
            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
            }
            size--;
        }
        #endregion

        #region Display
        public void Display()
        {
            Node temp = head;

            while(temp != null)
            {
                Console.Write(temp.Value + "\t");
                temp = temp.Next;
            }
            Console.WriteLine();
        }
        #endregion

        #region FindmiddleElement
        public int FindmiddleElement()
        {
            Node current = head;
            Node temp = head;

            while(temp.Next != null && temp.Next.Next != null)
            {
                current = current.Next;
                temp = temp.Next.Next;
            }

            return current.Value;
        }
        #endregion
        
        #region ReverseLinkedList
        public void ReverseLinkedList()
        {
            Node prev = null;
            Node current = head;
            Node next;  
                           
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            head = prev; // Update the head to the last node (now the first node)
            Display();
        }
        #endregion

        #region Deletevaluebefore2
        public void Deletevaluebefore2(int value)
        {
            Node current = head;
            while (current.Next.Next.Next.Value != value)
            {
                current = current.Next;
            }

            current.Next = current.Next.Next;
        }

        #endregion

        #region Remove duplicate

        public void RemoveDuplicate( int val)
        {
            Node current = head;

            while (current != null)
            {
                Node trav = current.Next;

                while(trav.Next != null)
                {
                    if(current.Value == trav.Next.Value)
                    {
                        trav.Next = trav.Next.Next;
                    }
                    else
                    {
                        trav = trav.Next;   
                    }
                }
                current = current.Next;
            }
        }

        #endregion

        #region SecondLargest

        public void SecondLargest()
        {
            if(head.Next == null)
            {
                Console.WriteLine("Only one element in LinkedList");
            }
            else
            {
                int Largest = int.MinValue;
                int SecondLargest = int.MinValue;

                Node current = head;
                while (current != null)
                {
                    if(current.Value > Largest)
                    {
                        SecondLargest = Largest;
                        Largest = current.Value;
                    }
                    else if(current.Value >SecondLargest)
                    {
                        SecondLargest = current.Value;
                    }
                        current = current.Next;
                }

                Console.WriteLine($"Largest element is : {Largest}");
                Console.WriteLine($"Second element is : {SecondLargest}");
            }
        }

        #endregion

        #region SelectionSort

        public void SelectionSort()
        {
            if(head == null)
            {
                Console.WriteLine("Linkedlist is empty");
            }
            else
            {
                Node current = head;
                while (current != null)
                {
                    Node trav = current.Next;
                    while (trav != null)
                    {
                        if(current.Value > trav.Value)
                        {
                            int temp = current.Value;
                            current.Value = trav.Value;
                            trav.Value = temp;
                        }
                        trav = trav.Next;
                    }
                    current = current.Next;

                }
            }
        }

        #endregion

        #region BubbleSort

        public void BubbleSort()
        {
            if(head == null)
            {
                Console.WriteLine("Linkedlist is null");
            }
            else
            {
                Node current = head;
                while (current != null)
                {
                    Node trav = head;
                    while (trav != null)
                    {
                        if(trav.Value > trav.Next.Value)
                        {
                            int temp = trav.Value;
                            trav.Value = trav.Next.Value;
                            trav.Next.Value = temp; 
                        }
                        trav = trav.Next;
                    }
                    current = current.Next;
                }
            }
        }

        #endregion

        #region InsertionSort

        public void InsertionSort()
        {

        }

        #endregion

        #region PrimeNumber

        public void FindPrimeNumber()
        {
            Node current = head;

            while (current != null)
            {
                int value = 2;
                int flag = 0; // Reset flag for each number

                while (value <= current.Value / 2)
                {
                    if (current.Value % value == 0)
                    {
                        flag = 1;
                        break;
                    }
                    value++;
                }

                if (flag == 0)
                {
                    Console.WriteLine($"{current.Value} is a Prime Number");
                }
                else
                {
                    Console.WriteLine($"{current.Value} is not a Prime Number");
                }

                current = current.Next;
            }
        }


        #endregion

        #region PrintingAlternative

        public void PrintAlternative()
        {
            Console.WriteLine();

            if (head == null)
            {
                Console.WriteLine("LinkedList is empty");
                return;
            }

            Node odd = head.Next;
            Node even = head;

            while (odd != null && odd.Next != null)
            {
                Console.Write(odd.Value + " ");
                odd = odd.Next.Next;

                if (even.Next != null)
                {
                    Console.Write(even.Value + " ");
                    even = even.Next.Next;
                }
            }
            if (odd != null)
            {
                Console.Write(odd.Value + " ");
            }
            if(even != null)
            {
                Console.Write(even.Value + " ");
            }
        }


        #endregion



    }

}
