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
            

        

    }
}
