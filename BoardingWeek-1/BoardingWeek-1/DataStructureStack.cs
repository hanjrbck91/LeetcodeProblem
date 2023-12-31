using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BoardingWeek_1
{
    public class DataStructureStack
    {
        #region StackArray
        public class StackUsingArray
        {
            private int[] arr;
            private int top;
            private int size;

            public StackUsingArray(int size)
            {
                this.size = size;
                arr = new int[size];
                top = -1;
            }

            #region Push
            public void Push(int value)
            {
                if (top == size - 1)
                {
                    throw new StackOverflowException("stack is full");
                }
                else
                {
                    top++;
                    arr[top] = value;
                }
            }
            #endregion

            #region Pop
            public int Pop()
            {
                if (top == -1)
                {
                    throw new InvalidOperationException("Stack is Empty");
                }
                else
                {
                    return arr[top--];
                }
            }
            #endregion

            #region Peek
            public int Peek()
            {
                if (top == -1)
                {
                    throw new InvalidOperationException("Empty stack");
                }
                else
                {
                    return arr[top];
                }
            }
            #endregion

            #region Display
            public void Display()
            {
                Array.Reverse(arr);
                Console.WriteLine("Stack Display is : ");
                foreach (int i in arr)
                {
                    Console.Write(i + "\t");
                }
            }
            #endregion

            #region MiddleElementRemoving

            public void RemoveMiddleElement(Stack<int> stack1)
            {
                Stack<int> stack2 = new Stack<int>(stack1.Count);

                int n = stack1.Count / 2;

                // Transfer the first half of elements from stack1 to stack2
                for (int i = 0; i < n; i++)
                {
                    stack2.Push(stack1.Pop());
                }

                // Skip the middle element
                stack1.Pop();

                // Transfer the elements back from stack2 to stack1
                while (stack2.Count > 0)
                {
                    stack1.Push(stack2.Pop());
                }

                // Print the modified stack1
                foreach (int k in stack1)
                {
                    Console.Write(k + " ");
                }
            }


            #endregion

        }
        #endregion

        #region StackLinkedList
        public class StackLinkedList
        {
            public class Node
            {
                public int Value;
                public Node? Next;

                public Node(int value)
                {
                    this.Value = value;
                }
            }

            public Node Head;
            public int Size { get; private set; }

            public StackLinkedList()
            {
                Head = null;
                Size = 0;
            }

            #region Push
            public void Push(int value)
            {
                Node data = new Node(value);

                if (Head == null)
                {
                    Head = data;
                }
                else
                {
                    data.Next = Head;
                    Head = data;
                }

                Size++;
            }
            #endregion

            #region Pop
            public int Pop() // Renamed from Pull to Pop (more conventional name)
            {
                Node current = Head.Next;
                if (Head == null)
                {
                    throw new InvalidOperationException("The stack is empty.");
                }
                else
                {
                    int poppedValue = Head.Value;
                    current = Head;
                    Size--;
                    return poppedValue;
                }
            }
            #endregion

            #region Peek
            public int Peek()
            {
                if (Head == null)
                {
                    throw new InvalidOperationException("The stack is empty");
                }
                else
                {
                    return Head.Value;
                }
            }
            #endregion

            #region Display
            public void Display()
            {
                if (Head == null)
                {
                    Console.WriteLine("The stack is empty.");
                    return;
                }

                Node current = Head;
                while (current != null)
                {
                    Console.Write(current.Value + "\t");
                    current = current.Next;
                }
                Console.WriteLine();
            }

            #endregion
        }
        #endregion
    }





}
