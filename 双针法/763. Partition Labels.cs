//Leetcode 763. Partition Labels med
//题意：给定一个字符串 s，要求将字符串划分为尽可能多的部分，使得每个字母最多只出现在一个部分中。划分的规则是在连接所有部分后，得到的字符串仍然是原始字符串 s。
//要求返回一个整数列表，表示这些部分的大小。
//思路：双指针，遍历字符串 s，记录每个字母最后出现的位置，存储在数组 lastOccurrence 中。
//使用两个指针 start 和 end 分别表示当前部分的开始和结束位置，初始化为 0。
//再次遍历字符串 s，对于每个字符，更新当前部分的结束位置 end。
//如果当前位置 i 等于当前部分的结束位置 end，说明当前部分结束，将当前部分的长度添加到结果列表中，并更新下一个部分的开始位置 start。        
//时间复杂度： O(n)，其中 n 是字符串的长度
//空间复杂度：O(1)
        public IList<int> PartitionLabels(string s)
        {
            List<int> result = new List<int>();

            // 记录每个字母最后出现的位置
            int[] lastOccurrence = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                lastOccurrence[s[i] - 'a'] = i;
            }

            int start = 0, end = 0;

            for (int i = 0; i < s.Length; i++)
            {
                // 更新当前部分的结束位置
                end = Math.Max(end, lastOccurrence[s[i] - 'a']);

                // 如果当前位置等于当前部分的结束位置，则当前部分结束
                if (i == end)
                {
                    result.Add(end - start + 1);
                    start = i + 1;  // 更新下一个部分的开始位置
                }
            }

            return result;
        }
