using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardingWeek_1
{
    public class Trie
    {
        // root declaration
        public TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        #region TrieNode Class
        // TrieNode Class declaration
        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; set; }
            public bool isEndOfWord;

            public TrieNode() 
            {
                Children = new Dictionary<char, TrieNode>();
                isEndOfWord = false;
            }
        }

        #endregion

        #region InsertString

        public void InsertString(string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                if(!node.Children.ContainsKey(c))
                {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
            }
            node.isEndOfWord = true;
        }
        #endregion

        #region Search

        public bool Search(string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                if (!node.Children.ContainsKey(c))
                {
                    return false;
                }
                node = node.Children[c];
            }

            return node.isEndOfWord;
        }

        #endregion

        #region StartsWith

        public bool Prefixsearch(string prefix)
        {
            TrieNode node = root;
            foreach(char c in prefix)
            {
                if(!node.Children.ContainsKey(c))
                {
                    return false;
                }
                node = node.Children[c];
            }
            return true;
        }

        #endregion

        #region DeleteRecursive

        // Public method to initiate the recursive deletion of a word from the Trie.
        public void Delete(string word)
        {
            // Call the private recursive delete method starting from the root.
            Delete(root, word, 0);
        }

        // Private recursive method to delete a word from the Trie.
        private bool Delete(TrieNode node, string word, int depth)
        {
            // Base case: If the current node is null, return false.
            if (node == null)
                return false;

            // If we have reached the end of the word.
            if (depth == word.Length)
            {
                // If the node does not represent the end of a word, return false.
                if (!node.isEndOfWord)
                    return false;

                // Mark the node as not representing the end of a word.
                node.isEndOfWord = false;

                // Delete the node if it has no children and is not the end of another word.
                return node.Children.Count == 0;
            }

            // Get the current character in the word.
            char currentChar = word[depth];

            // Recursively call delete for the next character in the word.
            if (Delete(node.Children[currentChar], word, depth + 1))
            {
                // If the child node is marked for deletion, remove it from the current node's children.
                node.Children.Remove(currentChar);

                // Delete the current node if it has no children and is not the end of another word.
                return node.Children.Count == 0 && !node.isEndOfWord;
            }

            // If the recursive delete did not result in removing the child node, return false.
            return false;
        }

        #endregion

        #region Delete Using Stack

        public void DeleteWord(string word)
        {
            TrieNode node = root;
            int depth = 0;

            Stack<TrieNode> stack = new Stack<TrieNode>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                TrieNode current = stack.Pop();

                if (depth == word.Length)
                {
                    if (!current.isEndOfWord)
                        continue;

                    current.isEndOfWord = false;

                    // Delete the node if it has no children and is not the end of another word
                    if (current.Children.Count == 0)
                        return;
                }

                char currentChar = word[depth];

                if (current.Children.TryGetValue(currentChar, out var nextNode))
                {
                    stack.Push(nextNode);
                    depth++;
                }
                else
                {
                    // Word not found, no need to continue
                    break;
                }
            }
        }


        #endregion

        #region CountWords

        public int CountWords()
        {
            return CountWords(root);
        }

        private int CountWords(TrieNode node)
        {
            if (node == null)
                return 0;

            int count = node.isEndOfWord ? 1 : 0;

            foreach (var child in node.Children.Values)
            {
                count += CountWords(child);
            }

            return count;
        }

        #endregion

        #region AutoComplete

        public List<string> AutoComplete(string prefix)
        {
            List<string> results = new List<string>();
            TrieNode node = root;

            // Traverse to the node representing the end of the prefix
            foreach (char c in prefix.ToLower())
            {
                if (!node.Children.ContainsKey(c))
                {
                    return results;
                }
                node = node.Children[c];
            }

            // Collect words starting from the node
            AutoComplete(node, prefix, results);
            return results;
        }

        private void AutoComplete(TrieNode node, string currentPrefix, List<string> results)
        {
            if (node.isEndOfWord)
            {
                results.Add(currentPrefix);
            }

            foreach (var child in node.Children)
            {
                AutoComplete(child.Value, currentPrefix + child.Key, results);
            }
        }

        #endregion

        #region LongestPrefixMatch

        public string LongestPrefixMatch(string input)
        {
            StringBuilder prefix = new StringBuilder();
            TrieNode node = root;

            foreach (char c in input.ToLower())
            {
                if (!node.Children.ContainsKey(c))
                {
                    break;
                }
                node = node.Children[c];
                prefix.Append(c);
            }

            return prefix.ToString();
        }

        #endregion

        #region WildcardMatch

        public List<string> WildcardMatch(string pattern)
        {
            List<string> results = new List<string>();
            WildcardMatch(root, pattern.ToLower(), 0, new StringBuilder(), results);
            return results;
        }

        private void WildcardMatch(TrieNode node, string pattern, int index, StringBuilder currentWord, List<string> results)
        {
            if (node == null)
                return;

            if (index == pattern.Length)
            {
                if (node.isEndOfWord)
                {
                    results.Add(currentWord.ToString());
                }
                return;
            }

            char currentChar = pattern[index];
            if (currentChar == '*')
            {
                foreach (var child in node.Children)
                {
                    WildcardMatch(child.Value, pattern, index + 1, currentWord.Append(child.Key), results);
                    currentWord.Length--; // Backtrack
                }
            }
            else
            {
                if (node.Children.ContainsKey(currentChar))
                {
                    WildcardMatch(node.Children[currentChar], pattern, index + 1, currentWord.Append(currentChar), results);
                    currentWord.Length--; // Backtrack
                }
            }
        }

        #endregion

        #region DisplayWords

        public void DisplayWords()
        {
            DisplayWords(root, "");
        }

        private void DisplayWords(TrieNode node, string currentWord)
        {
            if (node.isEndOfWord)
            {
                Console.WriteLine(currentWord);
            }

            foreach (var child in node.Children)
            {
                DisplayWords(child.Value, currentWord + child.Key);
            }
        }

        #endregion
    }
}
