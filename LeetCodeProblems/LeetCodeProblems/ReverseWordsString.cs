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
        /// <summary>
        /// Leetcode 1486
        /// </summary>
        /// <param name="n"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public int XorOperation(int n, int start)
        {

            int[] nums = new int[n];


            for (int i = 0; i < n; i++)
            {
                nums[i] = start + (2 * i);
            }
            int result = 0;

            foreach (int s in nums)
            {
                result ^= s;
            }

            return result;

        }

        /// <summary>
        /// Leetcode 1507
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string ReformatDate(string date)
        {
            string[] parts = date.Split(' ');
            int day = int.Parse(parts[0].Substring(0, parts[0].Length - 2));
            string month = GetMonth(parts[1]);
            string year = parts[2];
            return $"{year}-{month}-{day.ToString("D2")}";
        }

        private string GetMonth(string month)
        {
            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            int index = Array.IndexOf(months, month) + 1;
            return index.ToString("D2");
        }

        /// <summary>
        /// Leetcode 1458
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int MaxDotProduct(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            int[,] dp = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    dp[i, j] = Math.Max(nums1[i - 1] * nums2[j - 1] + dp[i - 1, j - 1], dp[i - 1, j]);
                    dp[i, j] = Math.Max(dp[i, j], dp[i, j - 1]);
                    dp[i, j] = Math.Max(dp[i, j], nums1[i - 1] * nums2[j - 1]);
                }
            }

            int result = dp[m, n];
            if (result == 0)
            {
                // Handle the case when there are no non-empty subsequences with the same length
                result = Int32.MinValue;
                for (int i = 0; i < m; i++)
                {
                    result = Math.Max(result, nums1[i] * nums2[0]);
                }
                for (int j = 1; j < n; j++)
                {
                    result = Math.Max(result, nums1[0] * nums2[j]);
                }
            }

            return result;
        }

        /// <summary>
        /// Leetcode 1523
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public int countOdds(int low, int high)
        {
            int count = 0;

            for (int i = low; i <= high; i++)
            {
                if (i % 2 == 1)
                {
                    count++;
                }
            }

            return count;

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
