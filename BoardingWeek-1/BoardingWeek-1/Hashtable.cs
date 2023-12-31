using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardingWeek_1
{
    public class MyHashtable
    {
        public string[] arr;
        int size;

        public MyHashtable(int size)
        {
            this.size = size;
            arr = new string[size];
        }

        public int GetHash(int key)
        {
            return key % this.size;
        }

        public void SetValue(int key, string value)
        {
            arr[GetHash(key)] = value;
        }

        public string GetValue(int key)
        {
            return arr[GetHash(key)];
        }

        public bool LinearProbeSetValue(int key, string value)
        {
            if (arr[GetHash(key)] != value)
            {
                // Linear probing until an empty slot is found or the array is full
                for (int i = 0; i < arr.Length; i++)
                {
                    int probeIndex = GetHash(key + i);
                    if (arr[probeIndex] == null)  // Assuming null represents an empty slot
                    {
                        arr[probeIndex] = value;
                        return true;  // Insertion successful
                    }
                }
            }
            // Array is full, couldn't insert
            return false;
        }
    }


}
