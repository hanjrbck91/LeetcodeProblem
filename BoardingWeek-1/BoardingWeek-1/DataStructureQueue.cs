using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BoardingWeek_1
{
    public class DataStructureQueue
    {
        #region QueueArray

        public class QueueArray
        {
            private int[] queueArray;
            private int front = -1;
            private int back = -1;
            private int size;

            public QueueArray(int size)
            {
                this.size = size;
                queueArray = new int[size];
            }

            #region Enqueue
            public void Enqueue(int value)
            {
                if(back == queueArray.Length-1)
                {
                    throw new Exception("Queue overflow");
                }
                else
                {
                    back++;
                    queueArray[back] = value;
                    if(front == -1)
                    {
                        front++;
                    }
                }
            }
            #endregion

            #region Dequeue
            public int Dequeue()
            {
                int value;

                if(front == -1)
                {
                    throw new Exception("Queue is underflow");
                }
                else if(front == back)
                {
                    front = -1;
                    back = -1;
                    value = queueArray[front];
                }
                else
                {
                    value = queueArray[front];
                    front++;
                }

                return value;
            }

            #endregion

            #region DisplayQueue
            
            public void Display()
            {
                Console.WriteLine("Queue in the order :");
               for(int i = front; i <= back; i++)
                
                    Console.Write(queueArray[i] + "\t");
                
               Console.WriteLine();
            }

            #endregion
        }

        #endregion

        #region QueueLinkedList

        public class QueueLinkedList
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

            public Node? Head;
            public int size;

            public QueueLinkedList()
            {
                Head = null;
                size = 0;
            }

            #region Enqueue

            public void Enqueue(int value)
            {
                Node newNode = new Node(value);
                if (Head == null)
                {
                    Head = newNode;
                }
                else
                {
                    Node current = Head;
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }
                    current.Next = newNode;
                }
                size++;
            }

            #endregion

            #region Dequeue

            public int Dequeue()
            {
                if (Head == null)
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                int data = Head.Value;
                Head = Head.Next;
                size--;
                return data;
            }

            #endregion

            #region Display 

            public void Display()
            {
                Console.WriteLine("Queue Elements are: ");
                Node? current = Head;
                while (current != null)
                {
                    Console.Write(current.Value + " ");
                    current = current.Next;
                }
                Console.WriteLine();
            }

            #endregion
        }


        #endregion
        

    }
}
