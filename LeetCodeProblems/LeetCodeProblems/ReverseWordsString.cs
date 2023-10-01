using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    internal class ReverseWordsString
    {/// <summary>
    /// Leetcode Qestion 557
    /// </summary>
        public class Solution
        {
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
        }

    }
}
