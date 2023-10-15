//Leetcode 131 Palindrome Partitioning med
//题意：给定一个字符串，将其分割成若干个子串，使得每个子串都是回文串。返回所有可能的分割方案。
//思路：深度优先搜索（DFS）: 遍历字符串的所有可能的起始位置，从每个起始位置开始进行深度优先搜索，尝试将当前位置到末尾的子串分割成回文串。在搜索过程中，通过判断子串是否是回文串来决定是否继续递归
//时间复杂度:  符串的长度为 n, O(n * 2^n)
//空间复杂度： O(n)
        public IList<IList<string>> Partition(string s)
        {
            IList<IList<string>> result = new List<IList<string>>();
            Partition_DFS(s, 0, new List<string>(), result);
            return result;
        }

        private void Partition_DFS(string s, int start, List<string> path, IList<IList<string>> result)
        {
            if (start == s.Length)
            {
                result.Add(new List<string>(path));
                return;
            }

            for (int i = start; i < s.Length; i++)
            {
                string subString = s.Substring(start, i - start + 1);
                if (IsPalindrome(subString))
                {
                    path.Add(subString);
                    Partition_DFS(s, i + 1, path, result);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }

        private bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }