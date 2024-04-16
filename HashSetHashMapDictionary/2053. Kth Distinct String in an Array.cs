//Leetcode 2053. Kth Distinct String in an Array ez
//题意：给定一个字符串数组 arr 和一个整数 k，要求找出数组中第 k 个出现次数为 1 的字符串。
//如果数组中不足 k 个出现次数为 1 的字符串，则返回空字符串 ""。
//思路：hashtable 使用哈希表记录每个字符串的出现次数。
//遍历字符串数组，统计每个字符串的出现次数。
//再次遍历字符串数组，找到第 k 个出现次数为 1 的字符串
//时间复杂度：O(n)
//空间复杂度：O(1)
        public string KthDistinct(string[] arr, int k)
        {
            Dictionary<string, int> frequency = new Dictionary<string, int>();

            // 统计每个字符串的出现次数
            foreach (string s in arr)
            {
                if (!frequency.ContainsKey(s))
                {
                    frequency[s] = 0;
                }
                frequency[s]++;
            }

            int distinctCount = 0;
            foreach (string s in arr)
            {
                if (frequency[s] == 1)
                {
                    distinctCount++;
                    if (distinctCount == k)
                    {
                        return s;
                    }
                }
            }

            return "";
        }