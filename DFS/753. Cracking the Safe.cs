//Leetcode 753. Cracking the Safe hard
//题意：有一个保险柜，密码是一个由 n 个数字组成的序列，每个数字都在范围 [0, k - 1] 中。
//保险柜有一种特殊的密码检查方式。当输入一个序列时，它每次检查最近输入的 n 个数字。
//例如，正确的密码是 "345"，你输入 "012345"：
//输入 0 后，最近 3 个数字是 "0"，是错误的。
//输入 1 后，最近 3 个数字是 "01"，是错误的。
//输入 2 后，最近 3 个数字是 "012"，是错误的。
//输入 3 后，最近 3 个数字是 "123"，是错误的。
//输入 4 后，最近 3 个数字是 "234"，是错误的。
//输入 5 后，最近 3 个数字是 "345"，是正确的，保险柜解锁。
//返回任何能在某个时刻解锁保险柜的最短字符串。
//思路：（DFS）来解决。我们需要构造一个字符串，确保每个新的 n 位序列都不在之前出现过。首先，我们从任意 n 位的序列开始，然后在每一步都尽量选择一个新的数字，确保这个新的数字不在之前的序列中。这个过程中，我们会记录已经出现过的序列。
//时间复杂度: O(k^n)
//空间复杂度：O(k^n)
        public string CrackSafe(int n, int k)
        {
            int totalPasswords = (int)Math.Pow(k, n);
            HashSet<string> seen = new HashSet<string>();
            StringBuilder result = new StringBuilder();

            string initial = new string('0', n);
            result.Append(initial);
            seen.Add(initial);

            DFS_CrackSafe(initial, totalPasswords, n, k, seen, result);
            return result.ToString();
        }

        private bool DFS_CrackSafe(string current, int totalPasswords, int n, int k, HashSet<string> seen, StringBuilder result)
        {
            if (seen.Count == totalPasswords)
            {
                return true; // All possible passwords have been generated
            }

            string suffix = current.Substring(current.Length - n + 1);
            for (int i = 0; i < k; i++)
            {
                string next = suffix + i.ToString();
                if (!seen.Contains(next))
                {
                    seen.Add(next);
                    result.Append(i);
                    if (DFS_CrackSafe(next, totalPasswords, n, k, seen, result))
                    {
                        return true;
                    }
                    result.Remove(result.Length - 1, 1); // Backtrack
                    seen.Remove(next);
                }
            }

            return false;
        }