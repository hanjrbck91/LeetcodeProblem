using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    internal class ReverseWordsString
    {/// <summary>
    /// Leetcode Qestions
    /// </summary>
    /// 
        //Leetcode 557
        public string ReverseWords(string s)
            {
                StringBuilder result = new StringBuilder();
                int start = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ' ')
                    {
                        for (int j = i - 1; j >= start; j--)
                        {
                            result.Append(s[j]);
                        }
                        result.Append(' '); // Add the space after reversing the word
                        start = i + 1; // Set the start index for the next word
                    }
                }

                // Reverse the last word
                for (int j = s.Length - 1; j >= start; j--)
                {
                    result.Append(s[j]);
                }

                return result.ToString();
            }

        //Leetcode 1450
        public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
                {
                    int n = startTime.Length;
                    int numStudent = 0;

                    for (int i = 0; i < n; i++)
                    {
                        if (queryTime >= startTime[i] && queryTime <= endTime[i])
                        {
                            numStudent++;
                        }
                    }

                    return numStudent;
                }

        /// <summary>
        /// Leetcode 2038
        /// </summary>
        /// <param name="colors"></param>
        /// <returns></returns>
        public bool WinnerOfGame(string colors)
        {
            string substringAAA = "AAA";
            int countAAA = CountSubstringOccurrences(colors, substringAAA);

            string substringBBB = "BBB";
            int countBBB = CountSubstringOccurrences(colors, substringBBB);

            if (countAAA > countBBB)
            {
                return true;
            }
            else if (colors.Length < 4)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public int CountSubstringOccurrences(string input, string substring)
        {
            int count = 0;
            int index = input.IndexOf(substring);

            while (index != -1)
            {
                count++;
                index = input.IndexOf(substring, index + 1);
            }

            return count;
        }

        // Leetcode 1512
        public int NumIdenticalPairs(int[] nums)
        {
            int pair = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        pair++;
                    }
                }
            }
            return pair;
        }

        // Leetcode 1470
        public int[] Shuffle(int[] nums, int n)
        {
            int[] arr = new int[nums.Length];
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                arr[j++] = nums[i];
                arr[j++] = nums[n + i];
            }
            return arr;
        }

        /// <summary>
        /// Leetcode 1475
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
           public int[] FinalPrices(int[] prices)
            {
                int[] discountPrice = new int[prices.Length];
                Array.Copy(prices, discountPrice, prices.Length);

                for (int i = 0; i < prices.Length - 1; i++)
                {
                    for (int j = i + 1; j < prices.Length; j++)
                    {
                        if (prices[i] >= prices[j])
                        {
                            discountPrice[i] = prices[i] - prices[j];
                            break;
                        }
                    }
                }

                return discountPrice;
            }
      


    }


    /// <summary>
    /// Leetcode 706
    /// </summary>
    public class MyHashMap
    {
        private const int Capacity = 1000001; // Maximum capacity based on constraints
        private int[] keys;
        private int[] values;

        public MyHashMap()
        {
            keys = new int[Capacity];
            values = new int[Capacity];
            Array.Fill(keys, -1); // Initialize keys to -1 (indicating empty)
        }

        public void Put(int key, int value)
        {
            int index = Hash(key);
            keys[index] = key;
            values[index] = value;
        }

        public int Get(int key)
        {
            int index = Hash(key);
            if (keys[index] == key)
            {
                return values[index];
            }
            return -1;
        }

        public void Remove(int key)
        {
            int index = Hash(key);
            if (keys[index] == key)
            {
                keys[index] = -1; // Mark as empty
            }
        }

        // Custom hash function to map keys to indices
        private int Hash(int key)
        {
            return key % Capacity;
        }
    }
}
